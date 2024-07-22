using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HexComparison.DataBlock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HexComparison
{
    public partial class MainForm : Form
    {
        private enum diffDirection
        {
            UP,
            DOWN,
            TOP,
            BOTTOM
        }
        private List<HexFile> listOfFiles = new List<HexFile>();
        private string ASCIIColumnName = "ASCII";
        private DataGridViewCellStyle notFoundStyle = new DataGridViewCellStyle();
        private DataGridViewCellStyle differentStyle = new DataGridViewCellStyle();

        public List<HexFile> ListOfFiles { get { return listOfFiles; } }

        public MainForm()
        {
            notFoundStyle.BackColor = Color.Orange;
            differentStyle.BackColor = Color.Red;
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool OpenHexFile(System.Windows.Forms.TextBox hexFileTextBox)
        {
            ofdOpenFiles.Title = "Open Hex File";
            ofdOpenFiles.Filter = "SRecord (*.s19;*.srec)|*.s19;*.srec|All files (*.*)|*.*";
            ofdOpenFiles.FileName = "";
            ofdOpenFiles.Multiselect = false;
            DialogResult resultFiles = ofdOpenFiles.ShowDialog();
            if (resultFiles != DialogResult.OK) { return false; }
            foreach (string file in ofdOpenFiles.FileNames)
            {
                hexFileTextBox.Text = file;
                HexFile hexFile = new HexFile(file);
                bool fileAlreadyOpened = false;
                foreach (HexFile loadedFile in listOfFiles)
                {
                    if (loadedFile.FilePath == file)
                    {
                        fileAlreadyOpened = true;
                        hexFile = loadedFile;
                        break;
                    }
                }
                hexFile.ReadFile();
                if (!fileAlreadyOpened) { listOfFiles.Add(hexFile); }
            }
            return true;
        }

        private void PopulateDataGridView(System.Windows.Forms.TextBox hexFileTextBox, DataGridView hexDgv, bool keepPreviousView = false)
        {
            int previousFirstRowShownIndex = 0;
            if (keepPreviousView && hexDgv.Rows.Count > 0)
            {
                previousFirstRowShownIndex = hexDgv.FirstDisplayedScrollingRowIndex;
            }

            hexDgv.Rows.Clear();
            hexDgv.Columns.Clear();
            HexFile file = null;
            foreach (HexFile loadedFile in listOfFiles)
            {
                if (loadedFile.FilePath == hexFileTextBox.Text)
                {
                    file = loadedFile;
                    break;
                }
            }
            if (file == null) { return; }

            hexDgv.SuspendLayout();
            hexDgv.ColumnHeadersVisible = true;
            hexDgv.Columns.Add("Address", "Address");
            for (int i = 0; i < Properties.Settings.Default.numberOfBytesPerLine; i++)
            {
                DataGridViewTextBoxColumn hexColumn = new DataGridViewTextBoxColumn();
                hexColumn.HeaderText = i.ToString("X");
                hexColumn.Name = "Byte" + (i + 1);
                hexColumn.Width = 30;
                hexDgv.Columns.Add(hexColumn);
            }
            DataGridViewTextBoxColumn ASCIIColumn = new DataGridViewTextBoxColumn();
            ASCIIColumn.HeaderText = "Text view";
            ASCIIColumn.Name = ASCIIColumnName;
            ASCIIColumn.Width = Properties.Settings.Default.numberOfBytesPerLine * 8;
            ASCIIColumn.Visible = showTextViewToolStripMenuItem.Checked;
            hexDgv.Columns.Add(ASCIIColumn);
            hexDgv.RowCount = file.NumberOfLines;
            if (keepPreviousView && hexDgv.Rows.Count > 0)
            {
                hexDgv.FirstDisplayedScrollingRowIndex = previousFirstRowShownIndex;
            }
            hexDgv.ResumeLayout();
        }

        private void UpdateDifferences()
        {
            HexFile referenceFile = null;
            HexFile comparedFile = null;
            foreach (HexFile file in listOfFiles)
            {
                file.ClearDataBlocksDifferences();
                if (tbReferenceFile.Text == file.FilePath) { referenceFile = file; }
                if (tbComparedFile.Text == file.FilePath) { comparedFile = file; }
            }
            if (referenceFile == null || comparedFile == null) { return; }

            referenceFile.CheckFileDifferences(comparedFile);
            comparedFile.CheckFileDifferences(referenceFile);
        }

        private void btnReferenceFile_Click(object sender, EventArgs e)
        {
            if (OpenHexFile(tbReferenceFile))
            {
                PopulateDataGridView(tbReferenceFile, dgvReferenceFile);
                PopulateDataGridView(tbComparedFile, dgvComparedFile, true);
                UpdateDifferences();
                UpdateInfoWindow(true, CreateHeaderInfoString(tbReferenceFile));
            }

        }

        private void btnOpenComparedFile_Click(object sender, EventArgs e)
        {
            if (OpenHexFile(tbComparedFile))
            {
                PopulateDataGridView(tbComparedFile, dgvComparedFile);
                PopulateDataGridView(tbReferenceFile, dgvReferenceFile, true);
                UpdateDifferences();
                UpdateInfoWindow(false, CreateHeaderInfoString(tbComparedFile));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvReferenceFile, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dgvComparedFile, new object[] { true });
        }

        private void CreateNewInfoWindow(bool isReference, string headerString)
        {
            InfoFile newInfoWindow = new InfoFile();
            newInfoWindow.IsReferenceInfo = isReference;
            if (isReference)
            {
                newInfoWindow.Text = "Reference Hex File log";
            }
            else
            {
                newInfoWindow.Text = "Compared Hex File log";
            }
            newInfoWindow.UpdateTextBox(headerString);
            newInfoWindow.Show();
        }

        private void UpdateInfoWindow(bool isReference, string headerString)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(InfoFile))
                {
                    InfoFile openInfo = (InfoFile)openForm;
                    if (openInfo.IsReferenceInfo == isReference)
                    {
                        openInfo.UpdateTextBox(headerString);
                        break;
                    }
                }
            }
        }

        private string CreateHeaderInfoString(System.Windows.Forms.TextBox textBox)
        {
            StringBuilder headerInfo = new StringBuilder();
            foreach (HexFile targetFile in listOfFiles)
            {
                if (targetFile.FilePath == textBox.Text)
                {
                    headerInfo.Append("File path : " + textBox.Text);
                    headerInfo.AppendLine();

                    for (int i = 0; i < targetFile.Blocks.Count(); i++)
                    {
                        string byteLength = targetFile.Blocks[i].BytesDataLength.ToString() + " Byte";
                        if (targetFile.Blocks[i].BytesDataLength > 1)
                        {
                            byteLength = byteLength + "s";
                        }

                        headerInfo.Append("Block " + (i + 1) + ", starts at : 0x" + targetFile.Blocks[i].BlockStartAddressUInt32.ToString("X8") + ", ends at : 0x" + targetFile.Blocks[i].EndAddress + ", length of " + byteLength + " (0x" + targetFile.Blocks[i].BytesDataLength.ToString("X") + ")");
                        headerInfo.AppendLine();
                    }
                    break;
                }
            }
            return headerInfo.ToString();
        }

        public bool ShowAddress(string address, bool isReference, int firstVisibleRowIndex = -1)
        {
            if (!Helper.IsHexadecimal(address)) { return false; }
            string fileName = tbComparedFile.Text;
            DataGridView hexDgv = dgvComparedFile;
            if (isReference)
            {
                fileName = tbReferenceFile.Text;
                hexDgv = dgvReferenceFile;
            }
            if (fileName == null) { return false; }
            HexFile targetFile = null;
            foreach (HexFile openFile in listOfFiles)
            {
                if (openFile.FilePath == fileName)
                {
                    targetFile = openFile;
                    break;
                }
            }
            if (targetFile == null) { return false; }
            int lineCount = 0;
            bool addressFound = false;
            foreach (DataBlock block in targetFile.Blocks)
            {
                int lineNumber = block.LineNumberFoundAddress(address);
                if (lineNumber == -1)
                {
                    lineNumber = block.NumberOfLines;
                    lineCount += lineNumber;
                }
                else
                {
                    addressFound = true;
                    lineCount += lineNumber;
                    break;
                }
            }
            if (!addressFound) { return false; }

            if (lineCount > hexDgv.Rows.Count) { return false; }

            int cellLineIndex = 1;
            string lineStartAddress = hexDgv.Rows[lineCount - 1].Cells[0].Value.ToString();
            if (Helper.IsHexadecimal(lineStartAddress))
            {
                UInt32 lineStartAddressUint = Convert.ToUInt32(lineStartAddress, 16);
                UInt32 targetAddress = Convert.ToUInt32(address, 16);
                cellLineIndex += Convert.ToInt32(targetAddress - lineStartAddressUint);
                cellLineIndex = Math.Min(cellLineIndex, Properties.Settings.Default.numberOfBytesPerLine);
            }

            hexDgv.CurrentCell = hexDgv.Rows[lineCount - 1].Cells[cellLineIndex];
            if (firstVisibleRowIndex == -1)
            {
                hexDgv.FirstDisplayedScrollingRowIndex = lineCount - 1;
            }
            else
            {
                hexDgv.FirstDisplayedScrollingRowIndex = Math.Max(0, lineCount - firstVisibleRowIndex - 1);
            }


            return true;
        }

        private string GetCellHexAddress(DataGridView hexDgv, int rowIndex, int columnIndex)
        {
            string baseRowAddress = hexDgv.Rows[rowIndex].Cells[0].Value.ToString();
            UInt32 longBaseAddress = Convert.ToUInt32(baseRowAddress, 16);
            longBaseAddress = longBaseAddress + Convert.ToUInt32(columnIndex - 1);
            return longBaseAddress.ToString("X8");
        }

        private bool ColumnExists(DataGridView hexDgv, string columnName)
        {
            foreach (DataGridViewColumn column in hexDgv.Columns)
            {
                if (column.Name == columnName)
                {
                    return true;
                }
            }
            return false;
        }

        private DataGridView GetDgvInFocus()
        {
            if (dgvReferenceFile.Focused == true)
            {
                return dgvReferenceFile;
            }
            else
            {
                return dgvComparedFile;
            }
        }

        private HexFile GetHexFileInFocus()
        {
            if (dgvReferenceFile.Focused == true)
            {
                foreach (HexFile file in listOfFiles)
                {
                    if (file.FilePath == tbReferenceFile.Text)
                    {
                        return file;
                    }
                }
            }
            else
            {
                foreach (HexFile file in listOfFiles)
                {
                    if (file.FilePath == tbComparedFile.Text)
                    {
                        return file;
                    }
                }
            }
            return null;
        }

        private void GoToDifference(diffDirection direction)
        {
            DataGridView dgvInFocus = GetDgvInFocus();
            HexFile fileInFocus = GetHexFileInFocus();
            bool isOtherDgvReference = false;
            if (dgvInFocus == dgvComparedFile)
            {
                isOtherDgvReference = true;
            }

            if (dgvInFocus.Rows.Count == 0) { return; }
            if (fileInFocus == null) { return; }
            if (fileInFocus.ListOfDifferences.Count == 0) { return; }

            List<Tuple<int, int>> listOfDifferences = fileInFocus.ListOfDifferences;
            int currentRowIndex = dgvInFocus.CurrentRow.Index;
            int currentCellIndex = dgvInFocus.CurrentCell.ColumnIndex;
            bool nextDiffFound = false;

            switch (direction)
            {
                case diffDirection.UP:
                    listOfDifferences.Reverse();

                    foreach (Tuple<int, int> difference in listOfDifferences)
                    {
                        if (difference.Item1 > currentRowIndex) { continue; }
                        if (difference.Item1 == currentRowIndex && difference.Item2 >= currentCellIndex) { continue; }
                        dgvInFocus.CurrentCell = dgvInFocus.Rows[difference.Item1].Cells[difference.Item2];
                        nextDiffFound = true;
                        break;
                    }

                    if (!nextDiffFound)
                    {
                        dgvInFocus.CurrentCell = dgvInFocus.Rows[listOfDifferences[0].Item1].Cells[listOfDifferences[0].Item2];
                    }

                    listOfDifferences.Reverse();
                    break;
                case diffDirection.DOWN:

                    foreach (Tuple<int, int> difference in listOfDifferences)
                    {
                        if (difference.Item1 < currentRowIndex) { continue; }
                        if (difference.Item1 == currentRowIndex && difference.Item2 <= currentCellIndex) { continue; }
                        dgvInFocus.CurrentCell = dgvInFocus.Rows[difference.Item1].Cells[difference.Item2];
                        nextDiffFound = true;
                        break;
                    }

                    if (!nextDiffFound)
                    {
                        dgvInFocus.CurrentCell = dgvInFocus.Rows[listOfDifferences[0].Item1].Cells[listOfDifferences[0].Item2];
                    }
                    break;
                case diffDirection.TOP:
                    dgvInFocus.CurrentCell = dgvInFocus.Rows[listOfDifferences[0].Item1].Cells[listOfDifferences[0].Item2];
                    break;
                case diffDirection.BOTTOM:
                    dgvInFocus.CurrentCell = dgvInFocus.Rows[listOfDifferences[listOfDifferences.Count - 1].Item1].Cells[listOfDifferences[listOfDifferences.Count - 1].Item2];
                    break;
            }
            if (coupleAddressToolStripMenuItem.Checked == true)
            {
                ShowAddress(GetCellHexAddress(dgvInFocus, dgvInFocus.CurrentCell.RowIndex, dgvInFocus.CurrentCell.ColumnIndex), isOtherDgvReference);
            }

        }

        private Tuple<DataBlock.DiffType, string> GetCellValueNeeded(string filePath, int rowIndex, int columnIndex)
        {
            HexFile file = null;
            foreach (HexFile loadedFile in listOfFiles)
            {
                if (loadedFile.FilePath == filePath)
                {
                    file = loadedFile;
                    break;
                }
            }
            if (file == null) { return new Tuple<DataBlock.DiffType, string>(DiffType.NotEvaluated, String.Empty); }
            if (columnIndex == 0)
            {
                return new Tuple<DataBlock.DiffType, string>(DiffType.NotEvaluated, file.GetDgvRowStartAddress(rowIndex));
            }
            else if (columnIndex == Properties.Settings.Default.numberOfBytesPerLine + 1)
            {
                return new Tuple<DataBlock.DiffType, string>(DiffType.NotEvaluated, file.GetDgvTextViewString(rowIndex));
            }
            else
            {
                return new Tuple<DataBlock.DiffType, string>(file.GetDgvDataCellDiffType(rowIndex, columnIndex - 1), file.GetDgvDataCellValue(rowIndex, columnIndex - 1));
            }
        }

        private void showInfoWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showInfoWindowsToolStripMenuItem.Checked)
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].GetType() == typeof(InfoFile)) { Application.OpenForms[i].Close(); }
                }
            }
            else
            {
                CreateNewInfoWindow(true, CreateHeaderInfoString(tbReferenceFile));
                CreateNewInfoWindow(false, CreateHeaderInfoString(tbComparedFile));
            }

            showInfoWindowsToolStripMenuItem.Checked = !showInfoWindowsToolStripMenuItem.Checked;
        }

        private void goToAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(GoToAddress))
                {
                    openForm.Focus();
                    return;
                }
            }
            GoToAddress goToAddress = new GoToAddress();
            goToAddress.Show();
        }

        private void viewNextDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToDifference(diffDirection.DOWN);
        }

        private void viewPreviousDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToDifference(diffDirection.UP);

        }

        private void viewFirstDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToDifference(diffDirection.TOP);
        }

        private void viewLastDifferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToDifference(diffDirection.BOTTOM);
        }

        private void showTextViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTextViewToolStripMenuItem.Checked = !showTextViewToolStripMenuItem.Checked;
            if (ColumnExists(dgvReferenceFile, ASCIIColumnName))
            {
                dgvReferenceFile.Columns[ASCIIColumnName].Visible = showTextViewToolStripMenuItem.Checked;
            }
            if (ColumnExists(dgvComparedFile, ASCIIColumnName))
            {
                dgvComparedFile.Columns[ASCIIColumnName].Visible = showTextViewToolStripMenuItem.Checked;
            }
        }

        private void dgvComparedFile_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (coupleAddressToolStripMenuItem.Checked == false) { return; }
            if (e.ColumnIndex == 0) { return; }
            if (e.ColumnIndex > Properties.Settings.Default.numberOfBytesPerLine) { return; }
            DataGridView currentDgv = (DataGridView)sender;
            ShowAddress(GetCellHexAddress(currentDgv, e.RowIndex, e.ColumnIndex), true, e.RowIndex - currentDgv.FirstDisplayedScrollingRowIndex);

        }

        private void dgvReferenceFile_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (coupleAddressToolStripMenuItem.Checked == false) { return; }
            if (e.ColumnIndex == 0) { return; }
            if (e.ColumnIndex > Properties.Settings.Default.numberOfBytesPerLine) { return; }
            DataGridView currentDgv = (DataGridView)sender;
            ShowAddress(GetCellHexAddress(currentDgv, e.RowIndex, e.ColumnIndex), false, e.RowIndex - currentDgv.FirstDisplayedScrollingRowIndex);
        }

        private void dgvReferenceFile_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            Tuple<DataBlock.DiffType, string> valueNeeded = GetCellValueNeeded(tbReferenceFile.Text, e.RowIndex, e.ColumnIndex);
            e.Value = valueNeeded.Item2;
            switch (valueNeeded.Item1)
            {
                case DiffType.NotFound:
                    dgvReferenceFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = notFoundStyle;
                    break;
                case DiffType.Different:
                    dgvReferenceFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = differentStyle;
                    break;
                default:
                    break;
            }

        }

        private void dgvComparedFile_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            Tuple<DataBlock.DiffType, string> valueNeeded = GetCellValueNeeded(tbComparedFile.Text, e.RowIndex, e.ColumnIndex);
            e.Value = valueNeeded.Item2;
            switch (valueNeeded.Item1)
            {
                case DiffType.NotFound:
                    dgvComparedFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = notFoundStyle;
                    break;
                case DiffType.Different:
                    dgvComparedFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = differentStyle;
                    break;
                default:
                    break;
            }
        }

        private void coupleAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coupleAddressToolStripMenuItem.Checked = !coupleAddressToolStripMenuItem.Checked;
        }

        private void showBlocksGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic graphic = new Graphic();
            graphic.Show();
        }
    }
}

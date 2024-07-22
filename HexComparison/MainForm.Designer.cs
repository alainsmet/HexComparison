namespace HexComparison
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            goToAddressToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            viewPreviousDifferenceToolStripMenuItem = new ToolStripMenuItem();
            viewNextDifferenceToolStripMenuItem = new ToolStripMenuItem();
            viewFirstDifferenceToolStripMenuItem = new ToolStripMenuItem();
            viewLastDifferenceToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            showInfoWindowsToolStripMenuItem = new ToolStripMenuItem();
            showTextViewToolStripMenuItem = new ToolStripMenuItem();
            coupleAddressToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            dgvReferenceFile = new Zuby.ADGV.AdvancedDataGridView();
            btnReferenceFile = new Button();
            label2 = new Label();
            tbReferenceFile = new TextBox();
            groupBox1 = new GroupBox();
            dgvComparedFile = new Zuby.ADGV.AdvancedDataGridView();
            btnOpenComparedFile = new Button();
            label1 = new Label();
            tbComparedFile = new TextBox();
            ofdOpenFiles = new OpenFileDialog();
            showBlocksGraphicToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReferenceFile).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComparedFile).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(964, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(135, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { goToAddressToolStripMenuItem, toolStripSeparator1, viewPreviousDifferenceToolStripMenuItem, viewNextDifferenceToolStripMenuItem, viewFirstDifferenceToolStripMenuItem, viewLastDifferenceToolStripMenuItem, toolStripSeparator2, showBlocksGraphicToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // goToAddressToolStripMenuItem
            // 
            goToAddressToolStripMenuItem.Name = "goToAddressToolStripMenuItem";
            goToAddressToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            goToAddressToolStripMenuItem.Size = new Size(264, 22);
            goToAddressToolStripMenuItem.Text = "Go to Address ...";
            goToAddressToolStripMenuItem.Click += goToAddressToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(261, 6);
            // 
            // viewPreviousDifferenceToolStripMenuItem
            // 
            viewPreviousDifferenceToolStripMenuItem.Name = "viewPreviousDifferenceToolStripMenuItem";
            viewPreviousDifferenceToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Up;
            viewPreviousDifferenceToolStripMenuItem.Size = new Size(264, 22);
            viewPreviousDifferenceToolStripMenuItem.Text = "View previous difference";
            viewPreviousDifferenceToolStripMenuItem.Click += viewPreviousDifferenceToolStripMenuItem_Click;
            // 
            // viewNextDifferenceToolStripMenuItem
            // 
            viewNextDifferenceToolStripMenuItem.Name = "viewNextDifferenceToolStripMenuItem";
            viewNextDifferenceToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Down;
            viewNextDifferenceToolStripMenuItem.Size = new Size(264, 22);
            viewNextDifferenceToolStripMenuItem.Text = "View next difference";
            viewNextDifferenceToolStripMenuItem.Click += viewNextDifferenceToolStripMenuItem_Click;
            // 
            // viewFirstDifferenceToolStripMenuItem
            // 
            viewFirstDifferenceToolStripMenuItem.Name = "viewFirstDifferenceToolStripMenuItem";
            viewFirstDifferenceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Up;
            viewFirstDifferenceToolStripMenuItem.Size = new Size(264, 22);
            viewFirstDifferenceToolStripMenuItem.Text = "View first difference";
            viewFirstDifferenceToolStripMenuItem.Click += viewFirstDifferenceToolStripMenuItem_Click;
            // 
            // viewLastDifferenceToolStripMenuItem
            // 
            viewLastDifferenceToolStripMenuItem.Name = "viewLastDifferenceToolStripMenuItem";
            viewLastDifferenceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Down;
            viewLastDifferenceToolStripMenuItem.Size = new Size(264, 22);
            viewLastDifferenceToolStripMenuItem.Text = "View last difference";
            viewLastDifferenceToolStripMenuItem.Click += viewLastDifferenceToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showInfoWindowsToolStripMenuItem, showTextViewToolStripMenuItem, coupleAddressToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // showInfoWindowsToolStripMenuItem
            // 
            showInfoWindowsToolStripMenuItem.Name = "showInfoWindowsToolStripMenuItem";
            showInfoWindowsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            showInfoWindowsToolStripMenuItem.Size = new Size(216, 22);
            showInfoWindowsToolStripMenuItem.Text = "Show Info Windows";
            showInfoWindowsToolStripMenuItem.Click += showInfoWindowsToolStripMenuItem_Click;
            // 
            // showTextViewToolStripMenuItem
            // 
            showTextViewToolStripMenuItem.Checked = true;
            showTextViewToolStripMenuItem.CheckState = CheckState.Checked;
            showTextViewToolStripMenuItem.Name = "showTextViewToolStripMenuItem";
            showTextViewToolStripMenuItem.Size = new Size(216, 22);
            showTextViewToolStripMenuItem.Text = "Show text view";
            showTextViewToolStripMenuItem.Click += showTextViewToolStripMenuItem_Click;
            // 
            // coupleAddressToolStripMenuItem
            // 
            coupleAddressToolStripMenuItem.Checked = true;
            coupleAddressToolStripMenuItem.CheckState = CheckState.Checked;
            coupleAddressToolStripMenuItem.Name = "coupleAddressToolStripMenuItem";
            coupleAddressToolStripMenuItem.Size = new Size(216, 22);
            coupleAddressToolStripMenuItem.Text = "Couple addresses";
            coupleAddressToolStripMenuItem.Click += coupleAddressToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(964, 510);
            splitContainer1.SplitterDistance = 480;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvReferenceFile);
            groupBox2.Controls.Add(btnReferenceFile);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(tbReferenceFile);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(480, 510);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reference Hex file";
            // 
            // dgvReferenceFile
            // 
            dgvReferenceFile.AllowUserToAddRows = false;
            dgvReferenceFile.AllowUserToDeleteRows = false;
            dgvReferenceFile.AllowUserToResizeColumns = false;
            dgvReferenceFile.AllowUserToResizeRows = false;
            dgvReferenceFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReferenceFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReferenceFile.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvReferenceFile.DefaultCellStyle = dataGridViewCellStyle1;
            dgvReferenceFile.FilterAndSortEnabled = false;
            dgvReferenceFile.FilterStringChangedInvokeBeforeDatasourceUpdate = false;
            dgvReferenceFile.Location = new Point(6, 55);
            dgvReferenceFile.Name = "dgvReferenceFile";
            dgvReferenceFile.ReadOnly = true;
            dgvReferenceFile.RightToLeft = RightToLeft.No;
            dgvReferenceFile.RowHeadersVisible = false;
            dgvReferenceFile.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvReferenceFile.RowTemplate.Height = 25;
            dgvReferenceFile.ShowCellErrors = false;
            dgvReferenceFile.ShowCellToolTips = false;
            dgvReferenceFile.ShowEditingIcon = false;
            dgvReferenceFile.ShowRowErrors = false;
            dgvReferenceFile.Size = new Size(468, 449);
            dgvReferenceFile.SortStringChangedInvokeBeforeDatasourceUpdate = false;
            dgvReferenceFile.TabIndex = 3;
            dgvReferenceFile.VirtualMode = true;
            dgvReferenceFile.CellMouseClick += dgvReferenceFile_CellMouseClick;
            dgvReferenceFile.CellValueNeeded += dgvReferenceFile_CellValueNeeded;
            // 
            // btnReferenceFile
            // 
            btnReferenceFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReferenceFile.Location = new Point(444, 25);
            btnReferenceFile.Name = "btnReferenceFile";
            btnReferenceFile.Size = new Size(30, 24);
            btnReferenceFile.TabIndex = 2;
            btnReferenceFile.Text = "...";
            btnReferenceFile.UseVisualStyleBackColor = true;
            btnReferenceFile.Click += btnReferenceFile_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 29);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "File :";
            // 
            // tbReferenceFile
            // 
            tbReferenceFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbReferenceFile.Location = new Point(43, 26);
            tbReferenceFile.Name = "tbReferenceFile";
            tbReferenceFile.ReadOnly = true;
            tbReferenceFile.Size = new Size(395, 23);
            tbReferenceFile.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvComparedFile);
            groupBox1.Controls.Add(btnOpenComparedFile);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbComparedFile);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 510);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Compared Hex file";
            // 
            // dgvComparedFile
            // 
            dgvComparedFile.AllowUserToAddRows = false;
            dgvComparedFile.AllowUserToDeleteRows = false;
            dgvComparedFile.AllowUserToResizeColumns = false;
            dgvComparedFile.AllowUserToResizeRows = false;
            dgvComparedFile.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvComparedFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComparedFile.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvComparedFile.DefaultCellStyle = dataGridViewCellStyle2;
            dgvComparedFile.FilterAndSortEnabled = false;
            dgvComparedFile.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            dgvComparedFile.Location = new Point(6, 55);
            dgvComparedFile.Name = "dgvComparedFile";
            dgvComparedFile.ReadOnly = true;
            dgvComparedFile.RightToLeft = RightToLeft.No;
            dgvComparedFile.RowHeadersVisible = false;
            dgvComparedFile.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvComparedFile.RowTemplate.Height = 25;
            dgvComparedFile.ShowCellErrors = false;
            dgvComparedFile.ShowCellToolTips = false;
            dgvComparedFile.ShowEditingIcon = false;
            dgvComparedFile.ShowRowErrors = false;
            dgvComparedFile.Size = new Size(468, 449);
            dgvComparedFile.SortStringChangedInvokeBeforeDatasourceUpdate = false;
            dgvComparedFile.TabIndex = 3;
            dgvComparedFile.VirtualMode = true;
            dgvComparedFile.CellMouseClick += dgvComparedFile_CellMouseClick;
            dgvComparedFile.CellValueNeeded += dgvComparedFile_CellValueNeeded;
            // 
            // btnOpenComparedFile
            // 
            btnOpenComparedFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenComparedFile.Location = new Point(444, 25);
            btnOpenComparedFile.Name = "btnOpenComparedFile";
            btnOpenComparedFile.Size = new Size(30, 24);
            btnOpenComparedFile.TabIndex = 2;
            btnOpenComparedFile.Text = "...";
            btnOpenComparedFile.UseVisualStyleBackColor = true;
            btnOpenComparedFile.Click += btnOpenComparedFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "File :";
            // 
            // tbComparedFile
            // 
            tbComparedFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbComparedFile.Location = new Point(43, 26);
            tbComparedFile.Name = "tbComparedFile";
            tbComparedFile.ReadOnly = true;
            tbComparedFile.Size = new Size(395, 23);
            tbComparedFile.TabIndex = 0;
            // 
            // ofdOpenFiles
            // 
            ofdOpenFiles.FileName = "openFileDialog1";
            // 
            // showBlocksGraphicToolStripMenuItem
            // 
            showBlocksGraphicToolStripMenuItem.Name = "showBlocksGraphicToolStripMenuItem";
            showBlocksGraphicToolStripMenuItem.Size = new Size(264, 22);
            showBlocksGraphicToolStripMenuItem.Text = "Show blocks graphic ...";
            showBlocksGraphicToolStripMenuItem.Click += showBlocksGraphicToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(261, 6);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 534);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Hex Comparison";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReferenceFile).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComparedFile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Button btnOpenComparedFile;
        private Label label1;
        private TextBox tbComparedFile;
        private Button btnReferenceFile;
        private Label label2;
        private TextBox tbReferenceFile;
        private Zuby.ADGV.AdvancedDataGridView dgvReferenceFile;
        private Zuby.ADGV.AdvancedDataGridView dgvComparedFile;
        private OpenFileDialog ofdOpenFiles;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem showInfoWindowsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem goToAddressToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem viewNextDifferenceToolStripMenuItem;
        private ToolStripMenuItem viewPreviousDifferenceToolStripMenuItem;
        private ToolStripMenuItem viewFirstDifferenceToolStripMenuItem;
        private ToolStripMenuItem viewLastDifferenceToolStripMenuItem;
        private ToolStripMenuItem showTextViewToolStripMenuItem;
        private ToolStripMenuItem coupleAddressToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem showBlocksGraphicToolStripMenuItem;
    }
}
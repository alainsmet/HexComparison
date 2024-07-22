using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexComparison
{
    public partial class GoToAddress : Form
    {
        public GoToAddress()
        {
            InitializeComponent();
        }

        private void GoToAddress_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            this.TopMost = true;
        }

        private void btnGoAddress_Click(object sender, EventArgs e)
        {
            SetAddressCell();
        }

        private void SetAddressCell()
        {
            tbOutputMessage.Text = string.Empty;
            string processedAddress = tbAddress.Text;

            if (processedAddress == "")
            {
                tbOutputMessage.Text = "ERROR : No address has been entered.";
                return; 
            }

            if (processedAddress.StartsWith("0x"))
            {
                processedAddress = processedAddress.Substring(2);
            }

            if (!Helper.IsHexadecimal(processedAddress))
            {
                tbOutputMessage.Text = "ERROR : The address entered is not a hexadecimal string.";
                return;
            }
            if (processedAddress.Length > 8)
            {
                tbOutputMessage.Text = "ERROR : The address entered is too long. Max 8 bytes (FFFFFFFF).";
                return;
            }

            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.GetType() == typeof(MainForm))
                {
                    MainForm mainForm = (MainForm)openForm;
                    StringBuilder sb = new StringBuilder();
                    if (rbReferenceFile.Checked || rbBothFiles.Checked)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }
                        if (mainForm.ShowAddress(processedAddress, true))
                        {
                            sb.Append("Address 0x" + processedAddress + " found in reference Hex file.");
                        } else
                        {
                            sb.Append("Address 0x" + processedAddress + " not found in reference Hex file.");
                        }
                    }
                    if (rbComparedFile.Checked || rbBothFiles.Checked)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendLine();
                        }
                        if(mainForm.ShowAddress(processedAddress, false))
                        {
                            sb.Append("Address 0x" + processedAddress + " found in compared Hex file.");
                        } else
                        {
                            sb.Append("Address 0x" + processedAddress + " not found in compared Hex file.");
                        }
                    }
                    tbOutputMessage.Text = sb.ToString();
                    break;
                }
            }
        }

        private void tbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SetAddressCell();
            }
        }
    }
}

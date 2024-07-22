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
    public partial class InfoFile : Form
    {
        public bool IsReferenceInfo;

        public InfoFile()
        {
            InitializeComponent();
        }

        public void UpdateTextBox(string text)
        {
            rtbInfo.Text = text;
        }

        private void InfoFile_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}

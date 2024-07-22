namespace HexComparison
{
    partial class InfoFile
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
            rtbInfo = new RichTextBox();
            SuspendLayout();
            // 
            // rtbInfo
            // 
            rtbInfo.Dock = DockStyle.Fill;
            rtbInfo.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rtbInfo.Location = new Point(0, 0);
            rtbInfo.Name = "rtbInfo";
            rtbInfo.Size = new Size(337, 530);
            rtbInfo.TabIndex = 0;
            rtbInfo.Text = "";
            // 
            // InfoFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 530);
            Controls.Add(rtbInfo);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InfoFile";
            Text = "InfoFile";
            Load += InfoFile_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbInfo;
    }
}
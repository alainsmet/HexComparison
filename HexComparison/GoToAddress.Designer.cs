namespace HexComparison
{
    partial class GoToAddress
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
            tbAddress = new TextBox();
            label1 = new Label();
            rbReferenceFile = new RadioButton();
            rbComparedFile = new RadioButton();
            rbBothFiles = new RadioButton();
            btnGoAddress = new Button();
            tbOutputMessage = new TextBox();
            SuspendLayout();
            // 
            // tbAddress
            // 
            tbAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbAddress.Location = new Point(118, 11);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(148, 23);
            tbAddress.TabIndex = 0;
            tbAddress.KeyPress += tbAddress_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 1;
            label1.Text = "Address to go to :";
            // 
            // rbReferenceFile
            // 
            rbReferenceFile.AutoSize = true;
            rbReferenceFile.Location = new Point(12, 47);
            rbReferenceFile.Name = "rbReferenceFile";
            rbReferenceFile.Size = new Size(166, 19);
            rbReferenceFile.TabIndex = 2;
            rbReferenceFile.Text = "Only for Reference Hex file";
            rbReferenceFile.UseVisualStyleBackColor = true;
            // 
            // rbComparedFile
            // 
            rbComparedFile.AutoSize = true;
            rbComparedFile.Location = new Point(12, 72);
            rbComparedFile.Name = "rbComparedFile";
            rbComparedFile.Size = new Size(170, 19);
            rbComparedFile.TabIndex = 2;
            rbComparedFile.Text = "Only for Compared Hex file";
            rbComparedFile.UseVisualStyleBackColor = true;
            // 
            // rbBothFiles
            // 
            rbBothFiles.AutoSize = true;
            rbBothFiles.Checked = true;
            rbBothFiles.Location = new Point(12, 97);
            rbBothFiles.Name = "rbBothFiles";
            rbBothFiles.Size = new Size(116, 19);
            rbBothFiles.TabIndex = 2;
            rbBothFiles.TabStop = true;
            rbBothFiles.Text = "For both hex files";
            rbBothFiles.UseVisualStyleBackColor = true;
            // 
            // btnGoAddress
            // 
            btnGoAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGoAddress.Location = new Point(277, 11);
            btnGoAddress.Name = "btnGoAddress";
            btnGoAddress.Size = new Size(75, 23);
            btnGoAddress.TabIndex = 3;
            btnGoAddress.Text = "Go";
            btnGoAddress.UseVisualStyleBackColor = true;
            btnGoAddress.Click += btnGoAddress_Click;
            // 
            // tbOutputMessage
            // 
            tbOutputMessage.Location = new Point(11, 132);
            tbOutputMessage.Multiline = true;
            tbOutputMessage.Name = "tbOutputMessage";
            tbOutputMessage.ReadOnly = true;
            tbOutputMessage.Size = new Size(341, 50);
            tbOutputMessage.TabIndex = 4;
            // 
            // GoToAddress
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 194);
            Controls.Add(tbOutputMessage);
            Controls.Add(btnGoAddress);
            Controls.Add(rbBothFiles);
            Controls.Add(rbComparedFile);
            Controls.Add(rbReferenceFile);
            Controls.Add(label1);
            Controls.Add(tbAddress);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GoToAddress";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Go to Address";
            Load += GoToAddress_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbAddress;
        private Label label1;
        private RadioButton rbReferenceFile;
        private RadioButton rbComparedFile;
        private RadioButton rbBothFiles;
        private Button btnGoAddress;
        private TextBox tbOutputMessage;
    }
}
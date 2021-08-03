namespace WhatsappBulk
{
    partial class FormWhatsappBulk
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
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.lblCsvFile = new System.Windows.Forms.Label();
            this.txbCSVFile = new System.Windows.Forms.TextBox();
            this.btnCSVFile = new System.Windows.Forms.Button();
            this.lstImage = new System.Windows.Forms.ListBox();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.lblIstirahat1 = new System.Windows.Forms.Label();
            this.txbUserCount = new System.Windows.Forms.TextBox();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSyncEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(373, 32);
            this.tbxMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(397, 206);
            this.tbxMessage.TabIndex = 0;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(673, 261);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(100, 28);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblCsvFile
            // 
            this.lblCsvFile.AutoSize = true;
            this.lblCsvFile.Location = new System.Drawing.Point(16, 11);
            this.lblCsvFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCsvFile.Name = "lblCsvFile";
            this.lblCsvFile.Size = new System.Drawing.Size(69, 17);
            this.lblCsvFile.TabIndex = 2;
            this.lblCsvFile.Text = "CSV File :";
            // 
            // txbCSVFile
            // 
            this.txbCSVFile.Location = new System.Drawing.Point(16, 32);
            this.txbCSVFile.Margin = new System.Windows.Forms.Padding(4);
            this.txbCSVFile.Name = "txbCSVFile";
            this.txbCSVFile.ReadOnly = true;
            this.txbCSVFile.Size = new System.Drawing.Size(288, 22);
            this.txbCSVFile.TabIndex = 3;
            // 
            // btnCSVFile
            // 
            this.btnCSVFile.Location = new System.Drawing.Point(317, 30);
            this.btnCSVFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCSVFile.Name = "btnCSVFile";
            this.btnCSVFile.Size = new System.Drawing.Size(43, 28);
            this.btnCSVFile.TabIndex = 4;
            this.btnCSVFile.Text = "...";
            this.btnCSVFile.UseVisualStyleBackColor = true;
            this.btnCSVFile.Click += new System.EventHandler(this.btnCSVFile_Click);
            // 
            // lstImage
            // 
            this.lstImage.FormattingEnabled = true;
            this.lstImage.ItemHeight = 16;
            this.lstImage.Location = new System.Drawing.Point(16, 106);
            this.lstImage.Margin = new System.Windows.Forms.Padding(4);
            this.lstImage.Name = "lstImage";
            this.lstImage.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstImage.Size = new System.Drawing.Size(339, 132);
            this.lstImage.TabIndex = 5;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(237, 70);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(119, 28);
            this.btnAddImage.TabIndex = 6;
            this.btnAddImage.Text = "Add Media/File";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lblIstirahat1
            // 
            this.lblIstirahat1.AutoSize = true;
            this.lblIstirahat1.Location = new System.Drawing.Point(20, 272);
            this.lblIstirahat1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIstirahat1.Name = "lblIstirahat1";
            this.lblIstirahat1.Size = new System.Drawing.Size(343, 17);
            this.lblIstirahat1.TabIndex = 7;
            this.lblIstirahat1.Text = "Banyak kontak yang harus dikirimkan sebelum jeda : ";
            // 
            // txbUserCount
            // 
            this.txbUserCount.Location = new System.Drawing.Point(372, 268);
            this.txbUserCount.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserCount.Name = "txbUserCount";
            this.txbUserCount.Size = new System.Drawing.Size(36, 22);
            this.txbUserCount.TabIndex = 8;
            this.txbUserCount.Text = "10";
            this.txbUserCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbUserCount_KeyPress);
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(780, 30);
            this.txbLog.Margin = new System.Windows.Forms.Padding(4);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbLog.Size = new System.Drawing.Size(363, 262);
            this.txbLog.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(369, 11);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(73, 17);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message :";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(776, 10);
            this.lblLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(40, 17);
            this.lblLog.TabIndex = 2;
            this.lblLog.Text = "Log :";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(111, 70);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 28);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSyncEmail
            // 
            this.btnSyncEmail.Location = new System.Drawing.Point(520, 261);
            this.btnSyncEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncEmail.Name = "btnSyncEmail";
            this.btnSyncEmail.Size = new System.Drawing.Size(132, 28);
            this.btnSyncEmail.TabIndex = 11;
            this.btnSyncEmail.Text = "Email Setting";
            this.btnSyncEmail.UseVisualStyleBackColor = true;
            this.btnSyncEmail.Click += new System.EventHandler(this.btnSyncEmail_Click);
            // 
            // FormWhatsappBulk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 309);
            this.Controls.Add(this.btnSyncEmail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.txbUserCount);
            this.Controls.Add(this.lblIstirahat1);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.lstImage);
            this.Controls.Add(this.btnCSVFile);
            this.Controls.Add(this.txbCSVFile);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblCsvFile);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbxMessage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormWhatsappBulk";
            this.Text = "WHATSAPP CUSTOMER RELATIONSHIP MANAGEMENT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWhatsappBulk_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label lblCsvFile;
        private System.Windows.Forms.TextBox txbCSVFile;
        private System.Windows.Forms.Button btnCSVFile;
        private System.Windows.Forms.ListBox lstImage;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Label lblIstirahat1;
        private System.Windows.Forms.TextBox txbUserCount;
        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSyncEmail;
    }
}


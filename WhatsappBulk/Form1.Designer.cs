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
            this.SuspendLayout();
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(280, 26);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(299, 168);
            this.tbxMessage.TabIndex = 0;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(505, 212);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // lblCsvFile
            // 
            this.lblCsvFile.AutoSize = true;
            this.lblCsvFile.Location = new System.Drawing.Point(12, 9);
            this.lblCsvFile.Name = "lblCsvFile";
            this.lblCsvFile.Size = new System.Drawing.Size(53, 13);
            this.lblCsvFile.TabIndex = 2;
            this.lblCsvFile.Text = "CSV File :";
            // 
            // txbCSVFile
            // 
            this.txbCSVFile.Location = new System.Drawing.Point(12, 26);
            this.txbCSVFile.Name = "txbCSVFile";
            this.txbCSVFile.ReadOnly = true;
            this.txbCSVFile.Size = new System.Drawing.Size(217, 20);
            this.txbCSVFile.TabIndex = 3;
            // 
            // btnCSVFile
            // 
            this.btnCSVFile.Location = new System.Drawing.Point(238, 24);
            this.btnCSVFile.Name = "btnCSVFile";
            this.btnCSVFile.Size = new System.Drawing.Size(32, 23);
            this.btnCSVFile.TabIndex = 4;
            this.btnCSVFile.Text = "...";
            this.btnCSVFile.UseVisualStyleBackColor = true;
            this.btnCSVFile.Click += new System.EventHandler(this.btnCSVFile_Click);
            // 
            // lstImage
            // 
            this.lstImage.FormattingEnabled = true;
            this.lstImage.Location = new System.Drawing.Point(12, 86);
            this.lstImage.Name = "lstImage";
            this.lstImage.Size = new System.Drawing.Size(255, 108);
            this.lstImage.TabIndex = 5;
            // 
            // btnAddImage
            // 
            this.btnAddImage.Location = new System.Drawing.Point(192, 57);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(75, 23);
            this.btnAddImage.TabIndex = 6;
            this.btnAddImage.Text = "Add Images";
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lblIstirahat1
            // 
            this.lblIstirahat1.AutoSize = true;
            this.lblIstirahat1.Location = new System.Drawing.Point(15, 221);
            this.lblIstirahat1.Name = "lblIstirahat1";
            this.lblIstirahat1.Size = new System.Drawing.Size(258, 13);
            this.lblIstirahat1.TabIndex = 7;
            this.lblIstirahat1.Text = "Banyak kontak yang harus dikirimkan sebelum jeda : ";
            // 
            // txbUserCount
            // 
            this.txbUserCount.Location = new System.Drawing.Point(279, 218);
            this.txbUserCount.Name = "txbUserCount";
            this.txbUserCount.Size = new System.Drawing.Size(28, 20);
            this.txbUserCount.TabIndex = 8;
            this.txbUserCount.Text = "10";
            this.txbUserCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbUserCount_KeyPress);
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(585, 24);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbLog.Size = new System.Drawing.Size(273, 214);
            this.txbLog.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(277, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(56, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message :";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(582, 8);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(31, 13);
            this.lblLog.TabIndex = 2;
            this.lblLog.Text = "Log :";
            // 
            // FormWhatsappBulk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 251);
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
            this.Name = "FormWhatsappBulk";
            this.Text = "WHATSAPP BULK";
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
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappLib;
using WhatsappLib.Helpers;

namespace WhatsappBulk
{
    public partial class FormWhatsappBulk : Form
    {
        public FormWhatsappBulk()
        {
            InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            btnSendMessage.Enabled = false;
            btnSendMessage.Refresh();
            string message = tbxMessage.Text;

            Whatsapp wa = new Whatsapp();
            wa.Run();

            while (!wa.CheckLoggedIn())
            {
                Console.WriteLine("Not login yet");
            }

            //wa.SendMessage("6287883711444", message);
            //string filepath = @"E:\image\images.png";
            string csvFile = txbCSVFile.Text;

            var contacts = CsvHelper.CsvToContact(csvFile);
            var fileCount = lstImage.Items.Count;

            string[] files = new string[fileCount];

            int index = 0;
            foreach(var image in lstImage.Items)
            {
                files[index] = image.ToString();
                index++;
            }

            string imagepath = String.Join("\n",files);

            Random rnd = new Random();
            int delay_antar_contact = 5000;
            int delay_x_contact = 0;
            int counterContact = 0;
            int nUserJeda = Convert.ToInt32(txbUserCount.Text);
            foreach (var contact in contacts)
            {
                //var msg = "Dear " + contact.Greeting + " " + contact.Name + ", \r\n";
                var msg = message.Replace("#nama#",contact.Name);
                msg = msg.Replace("#panggilan#",contact.Greeting);
                try
                {
                    if (fileCount > 0)
                    {
                        wa.SendImage(contact.Number, msg, imagepath);
                        txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        txbLog.Text += "Send message to  " + contact.Name +
                            " (" + contact.Number + ") success\r\n";
                    }
                    else
                    {
                        wa.SendMessage(contact.Number, msg);
                        txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        txbLog.Text += "Send message to  " + contact.Name +
                            " (" + contact.Number + ") success\r\n";
                    }
                }
                catch(Exception)
                {
                    txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                    txbLog.Text += "Send message to  " + contact.Name +
                            " (" + contact.Number + ") FAILED\r\n";
                }

                txbLog.Refresh();
                


                if ((++counterContact % nUserJeda) == 0)
                {
                    counterContact = 0;
                    delay_x_contact = 5 * 1000 * 60 + rnd.Next(12) * 1000 * 30;
                    Thread.Sleep(delay_x_contact);
                }
                else
                {
                    delay_antar_contact = (5 + rnd.Next(56)) * 1000;
                    Thread.Sleep(delay_antar_contact);
                }
                
            }

            btnSendMessage.Enabled = true;
            //wa.SendImageByPopup("6287883711444", files);
        }

        private void btnCSVFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            //openFileDialog.Filter = "CSV File | csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txbCSVFile.Text = openFileDialog.FileName;
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int x = 0; x < openFileDialog.FileNames.Count(); x++)
                {
                    lstImage.Items.Add(openFileDialog.FileNames[x]);
                }
            }
        }

        private void txbUserCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

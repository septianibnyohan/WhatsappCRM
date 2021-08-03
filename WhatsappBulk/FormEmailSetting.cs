using S22.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappLib.Helpers;

namespace WhatsappBulk
{
    public partial class FormEmailSetting : Form
    {
        public FormEmailSetting()
        {
            InitializeComponent();
            SetComponentValue();
        }

        private void SetComponentValue()
        {
            tbxEmail.Text = Properties.Settings.Default.Email;
            tbxPassword.Text = Properties.Settings.Default.Password;
            tbxHost.Text = Properties.Settings.Default.Imap;
            tbxPort.Text = Properties.Settings.Default.Port.ToString();
            tbxEmailFrom.Text = Properties.Settings.Default.EmailFrom;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tbxEmail.Text;
                string password = tbxPassword.Text;
                string host = tbxHost.Text;
                int port = Convert.ToInt32(tbxPort.Text);

                ImapClient client = new ImapClient(host,port, email, password, AuthMethod.Login, true);

                Properties.Settings.Default.Email = tbxEmail.Text;
                Properties.Settings.Default.Password = tbxPassword.Text;
                Properties.Settings.Default.Imap = tbxHost.Text;
                Properties.Settings.Default.Port = Convert.ToInt32(tbxPort.Text);
                Properties.Settings.Default.EmailFrom = tbxEmailFrom.Text;
                Properties.Settings.Default.Save();
                this.Hide();
            } 
            catch (Exception ex)
            {
                LogHelper.LogEx(ex);
                MessageBox.Show("Gagal Menyimpan!, Periksa lagi koneksi internet atau settingan email Anda.");
            }
            
        }

        private void tbxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappLib;

namespace WhatsappBulk
{
    public partial class FormKeygen : Form
    {
        public FormKeygen()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            string key = txbKEY.Text;

            if (Keygen.Check(key))
            {
                Keygen.GenerateLicense(key);
                Keygen.isActivated = true;

                this.Hide();
                var browserform = new FormBrowser();
                browserform.Show();
            }
            else
            {
                lblMessage.Text = "Key is not valid...!!!";
            }
        }

        private void FormKeygen_Load(object sender, EventArgs e)
        {
            txbID.Text = Keygen.GetSerialNumber();
        }
    }
}

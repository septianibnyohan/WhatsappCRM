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

namespace KeygenGenerator
{
    public partial class FormKeygen : Form
    {
        public FormKeygen()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string id = txbID.Text;
            string key = Keygen.GetSHA1(id);

            txbKEY.Text = key;
        }
    }
}

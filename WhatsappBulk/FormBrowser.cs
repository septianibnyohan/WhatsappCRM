using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsappBulk
{
    public partial class FormBrowser : Form
    {
        public FormBrowser()
        {
            InitializeComponent();
            cbxBrowser.Items.Add("Chrome");
            cbxBrowser.Items.Add("Firefox");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxBrowser.SelectedIndex == 0)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["WebDriver"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            else if (cbxBrowser.SelectedIndex == 1)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["WebDriver"].Value = "1";

                if (File.Exists("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe"))
                {
                    config.AppSettings.Settings["FirefoxLocation"].Value = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe";
                }
                else
                {
                    config.AppSettings.Settings["FirefoxLocation"].Value = "C:\\Program Files\\Mozilla Firefox\\firefox.exe";
                }

                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }

            this.Hide();
            var waform = new FormWhatsappBulk();
            waform.Show();
        }
    }
}

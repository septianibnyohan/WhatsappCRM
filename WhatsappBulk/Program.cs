using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsappLib;

namespace WhatsappBulk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Keygen.CheckLicense())
            {
                Application.Run(new FormBrowser());
                //Application.Run(new FormWhatsappBulk());
            }
            else
            {
                Application.Run(new FormKeygen());
                //Application.Run(new FormBrowser());
                //Application.Run(new FormWhatsappBulk());
            }

        }
    }
}

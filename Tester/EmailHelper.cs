using S22.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    class EmailHelper
    {
        public static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            Console.WriteLine("New Message Received");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            /*
            f.Invoke((MethodInvoker)delegate
            {

            });
            */
            string txtReceive = "From: " + m.From + "\n" +
                                "Subject: " + m.Subject + "\n" +
                                "Body: " + m.Body + "\n";
            Console.WriteLine(txtReceive);
        }
    }
}

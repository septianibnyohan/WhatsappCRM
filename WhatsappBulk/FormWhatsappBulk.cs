using S22.Imap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WhatsappBulk.Models;
using WhatsappLib;
using WhatsappLib.Helpers;
using WhatsappLib.Helpers.Logger;

namespace WhatsappBulk
{
    public partial class FormWhatsappBulk : Form
    {
        static Whatsapp wa;
        static FormWhatsappBulk f;
        FormEmailSetting frmEmailSetting;

        bool isSending;

        public FormWhatsappBulk()
        {
            InitializeComponent();
            f = this;
            frmEmailSetting = new FormEmailSetting();

            LogHelper.Log(LogTarget.File, "Initial");

            wa = new Whatsapp();
            wa.Run();
            while (!wa.CheckLoggedIn())
            {
                Console.WriteLine("Not login yet");
            }

            isSending = false;
            SyncEmail();
            //new AutoResponder().Run(wa);
        }

        private PrepareMessage PrepareSendMessage()
        {
            var prepMsg = new PrepareMessage();

            btnSendMessage.Enabled = false;
            btnSendMessage.Refresh();
            prepMsg.Message = tbxMessage.Text;

            LogHelper.Log(LogTarget.File, "Preparation Message : " + prepMsg.Message);

            string csvFile = txbCSVFile.Text;

            prepMsg.Contacts = CsvHelper.CsvToContact(csvFile);
            prepMsg.FileCount = lstImage.Items.Count;

            string[] files = new string[prepMsg.FileCount];

            int index = 0;
            foreach (var image in lstImage.Items)
            {
                files[index] = image.ToString();
                index++;
            }

            prepMsg.ImagePath = String.Join("\n", files);

            prepMsg.Rnd = new Random();
            prepMsg.DelayAntarContact = 5000;
            prepMsg.DelayXContact = 0;
            prepMsg.CounterContact = 0;
            prepMsg.NUserJeda = Convert.ToInt32(txbUserCount.Text);

            return prepMsg;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {

            try
            {
                isSending = true;
                var init = PrepareSendMessage();

                if (init.Contacts == null)
                {
                    MessageBox.Show("Error", "Incorrect CSV Format",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int counter = 0; int contact_sum = init.Contacts.Count;
                foreach (var contact in init.Contacts)
                {
                    //var msg = "Dear " + contact.Greeting + " " + contact.Name + ", \r\n";
                    var msg = init.Message.Replace("#nama depan#", contact.FirstName);
                    msg = msg.Replace("#nama belakang#", contact.LastName);
                    msg = msg.Replace("#panggilan#", contact.Greeting);
                    try
                    {
                        if (init.FileCount > 0)
                        {
                            wa.SendImage(contact.Number, msg, init.ImagePath);
                            txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                            txbLog.Text += "Send message to  " + contact.FirstName + " " + contact.LastName +
                                " (" + contact.Number + ") success\r\n";
                            LogHelper.Log(LogTarget.File, "Send message to  " + contact.FirstName + " " + contact.LastName +
                                " (" + contact.Number + ") success");
                        }
                        else
                        {
                            bool is_message_send = wa.SendMessage(contact.Number, msg);

                            if (is_message_send)
                            {
                                txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                                txbLog.Text += "Send message to  " + contact.FirstName + " " + contact.LastName +
                                    " (" + contact.Number + ") success\r\n";
                                LogHelper.Log(LogTarget.File, "Send message to  " + contact.FirstName + " " + contact.LastName +
                                    " (" + contact.Number + ") success");
                            }


                            if (!is_message_send)
                            {
                                f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                                f.txbLog.Text += contact.Number + " is not valid\r\n";
                                LogHelper.Log(LogTarget.File, contact.Number + " is not valid\r\n");
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        txbLog.Text += "Send message to  " + contact.FirstName + " " + contact.LastName +
                                " (" + contact.Number + ") FAILED\r\n";
                        LogHelper.Log(LogTarget.File, "Send message to  " + contact.FirstName + " " + contact.LastName +
                                " (" + contact.Number + ") FAILED");
                        LogHelper.LogEx(ex);
                    }

                    txbLog.Refresh();

                    if (++counter < contact_sum)
                    {
                        if ((++init.CounterContact % init.NUserJeda) == 0)
                        {
                            init.CounterContact = 0;
                            init.DelayXContact = 5 * 1000 * 60 + init.Rnd.Next(12) * 1000 * 30;
                            Thread.Sleep(init.DelayXContact);
                            LogHelper.Log(LogTarget.File, "Sleep " + init.DelayXContact);
                        }
                        else
                        {
                            init.DelayAntarContact = (5 + init.Rnd.Next(56)) * 1000;
                            Thread.Sleep(init.DelayAntarContact);
                            LogHelper.Log(LogTarget.File, "Sleep " + init.DelayAntarContact);
                        }
                    }
                }

                btnSendMessage.Enabled = true;
            }
            catch(Exception ex)
            {
                LogHelper.LogEx(ex);
            }

            isSending = false;
            LogHelper.Log(LogTarget.File, "End Preparation Message");
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lstImage);
            selectedItems = lstImage.SelectedItems;

            if (lstImage.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lstImage.Items.Remove(selectedItems[i]);
            }
        }

        private void btnOpenWA_Click(object sender, EventArgs e)
        {
            wa.Run();
        }

        private void btnSyncEmail_Click(object sender, EventArgs e)
        {
            if (frmEmailSetting.IsDisposed) frmEmailSetting = new FormEmailSetting();
            frmEmailSetting.Show();
        }

        private void SyncEmail()
        {
            Task.Run(() =>
            {
                //using (ImapClient client = new ImapClient(Properties.Settings.Default.Imap, Properties.Settings.Default.Port,
                //    Properties.Settings.Default.Email, Properties.Settings.Default.Password, AuthMethod.Login, true))
                //{
                    while (!isSending)
                    {
                        try
                        {
                            ImapClient client = new ImapClient(Properties.Settings.Default.Imap, Properties.Settings.Default.Port,
                             Properties.Settings.Default.Email, Properties.Settings.Default.Password, AuthMethod.Login, true);
                            
                            IEnumerable<uint> uids = client.Search(SearchCondition.Unseen());
                            IEnumerable<MailMessage> messages = client.GetMessages(uids);

                            foreach (var m in messages)
                            {
                                 ProcessMessage(m);
                                Thread.Sleep(5000);
                            }

                            client.Dispose();
                            Thread.Sleep(10000);
                        }   
                        catch( Exception ex)
                        {
                            //var error = "error : " + ex.Message + "\n";
                            //error += "stacktace : " + ex.StackTrace;
                            //LogHelper.Log(LogTarget.File, error);
                            LogHelper.LogEx(ex);
                            Thread.Sleep(1000);
                            continue;
                        }
                        
                    }

                    //if (client.Supports("IDLE") == false)
                    //{
                    //    MessageBox.Show("Server does not support IMAP IDLE");
                    //    return;
                    //}
                    //client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                    //while (true) ;
                //}

            });
        }

        private void ProcessMessage(MailMessage m)
        {
            string pre_wa = "Whatsapp:";
            LogHelper.Log(LogTarget.File, m.Body);

            if (m.From.Address.ToLower().Contains(Properties.Settings.Default.EmailFrom.ToLower()))
            {
                string contact_number = "085712345678";

                try
                {
                    var test = Converter.HtmlToPlainText(m.Body);
                    LogHelper.Log(LogTarget.File, test);

                    int index_wa = m.Body.IndexOf(pre_wa, 0) + pre_wa.Length;
                    int index_n = m.Body.IndexOf("\r\n", index_wa);

                    contact_number = m.Body.Substring(index_wa, index_n - index_wa).Trim();

                    if (!contact_number.All(char.IsDigit))
                    {
                        index_n = m.Body.IndexOf("\n", index_wa);
                        contact_number = m.Body.Substring(index_wa, index_n - index_wa).Trim();
                    }

                    //contact_number = contact_number.Replace("<br />", "").Trim();

                    if (contact_number.Length > 15)
                    {
                        index_n = m.Body.IndexOf("<", index_wa);
                        contact_number = m.Body.Substring(index_wa, index_n - index_wa).Trim();
                    }

                    //String indNumberStr = contact_number;
                    //PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

                    //PhoneNumber indNumberProto = phoneUtil.Parse(indNumberStr, "ID");
                    //contact_number = indNumberProto.CountryCode.ToString() + indNumberProto.NationalNumber.ToString();

                    //var message = HTMLToText(HttpUtility.HtmlDecode(m.Body));

                    var message = m.Body;
                    if (Properties.Settings.Default.IsHTML)
                    {
                        message = HTMLToText(message);
                        message = message.Replace("\r\n", "");
                    }
                    contact_number = PhoneHelper.FixPhoneNumber(contact_number);

                    bool is_message_send = wa.SendMessage(contact_number, message);

                    if (is_message_send)
                    {
                        f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        f.txbLog.Text += "Send message to  " + m.From +
                                " (" + contact_number + ") success\r\n";
                    }

                    if (!is_message_send)
                    {
                        f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        f.txbLog.Text += contact_number + " is not valid\r\n";
                    }
                }
                catch (Exception ex)
                {
                    f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                    f.txbLog.Text += "Send message to  " + m.From +
                            " (" + contact_number + ") FAILED\r\n";
                    LogHelper.LogEx(ex);
                }

                f.txbLog.Refresh();
            }
        }

        private void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);

            string pre_wa = "Whatsapp:";


            f.Invoke((MethodInvoker)delegate
            {
                if (m.From.Address.ToLower().Contains(Properties.Settings.Default.Email.ToLower()))
                {
                    string contact_number = "085712345678";
                    
                    try
                    {
                        int index_wa = m.Body.IndexOf(pre_wa, 0) + pre_wa.Length;
                        int index_n = m.Body.IndexOf("\r\n", index_wa);

                        contact_number = m.Body.Substring(index_wa, index_n - index_wa).Trim();

                        if (contact_number.Length > 18)
                        {
                            index_n = m.Body.IndexOf("<br />", index_wa);
                            contact_number = m.Body.Substring(index_wa, index_n - index_wa).Trim();
                        }

                        //String indNumberStr = contact_number;
                        //PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

                        //PhoneNumber indNumberProto = phoneUtil.Parse(indNumberStr, "ID");
                        //contact_number = indNumberProto.CountryCode.ToString() + indNumberProto.NationalNumber.ToString();

                        //var message = HTMLToText(HttpUtility.HtmlDecode(m.Body));
                        var message = HTMLToText(m.Body);
                        message = message.Replace("\r\n", "");
                        contact_number = PhoneHelper.FixPhoneNumber(contact_number);
                        wa.SendMessage(contact_number, message);

                        f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        f.txbLog.Text += "Send message to  " + m.From +
                                " (" + contact_number + ") success\r\n";
                    }
                    catch (Exception ex)
                    {
                        f.txbLog.Text += $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ";
                        f.txbLog.Text += "Send message to  " + m.From +
                                " (" + contact_number + ") FAILED\r\n";
                        LogHelper.LogEx(ex);
                    }
                    
                    f.txbLog.Refresh();
                }

            });
        }

        public static string HTMLToText(string HTMLCode)
        {
            StringBuilder sbHTML = null;
            try
            {
                // Remove new lines since they are not visible in HTML
                //HTMLCode = HTMLCode.Replace("\n", " ");

                // Remove tab spaces
                HTMLCode = HTMLCode.Replace("\t", " ");

                // Remove multiple white spaces from HTML
                //HTMLCode = Regex.Replace(HTMLCode, "\\s+", " ");

                // Remove HEAD tag
                HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", ""
                                    , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Remove any JavaScript
                HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", ""
                  , RegexOptions.IgnoreCase | RegexOptions.Singleline);

                // Replace special characters like &, <, >, " etc.
                sbHTML = new StringBuilder(HTMLCode);
                // Note: There are many more special characters, these are just
                // most common. You can add new characters in this arrays if needed
                string[] OldWords = {"&nbsp;", "&amp;", "&quot;", "&lt;",
                "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"};
                string[] NewWords = { " ", "&", "\"", "<", ">", "Â®", "Â©", "â€¢", "â„¢" };
                for (int i = 0; i < OldWords.Length; i++)
                {
                    sbHTML.Replace(OldWords[i], NewWords[i]);
                }

                // Check if there are line breaks (<br>) or paragraph (<p>)
                sbHTML.Replace("<br>", "\n<br>");
                sbHTML.Replace("<br", "\n<br");
                sbHTML.Replace("<p", "\n\n<p");
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(ex);
            }
            
            // Finally, remove all HTML tags and return plain text
            return System.Text.RegularExpressions.Regex.Replace(
              sbHTML.ToString(), "<[^>]*>", "");
        }

        public static string FixPhoneNumber(string phone_number)
        {
            string res_number = phone_number;
            try
            {
                
                if (res_number[0] == '8')
                {
                    res_number = "62" + res_number;
                    return res_number;
                }

                if (res_number[0] == '0')
                {
                    res_number = "62" + res_number.Substring(1);
                    return res_number;
                }

                if (res_number.Contains("+62"))
                {
                    res_number = res_number.Replace("+62", "62");
                    return res_number;
                }

                if (res_number.Contains("(62) "))
                {
                    res_number = res_number.Replace("(62) ", "62");
                    return res_number;
                }

                if (res_number.Contains("(+62) "))
                {
                    res_number = res_number.Replace("(+62) ", "62");
                    return res_number;
                }

                if (res_number.Contains("(628) "))
                {
                    res_number = res_number.Replace("(628) ", "62");
                    return res_number;
                }

                if (res_number.Contains("(+628) "))
                {
                    res_number = res_number.Replace("(+628) ", "62");
                    return res_number;
                }

                
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(ex);
            }

            return res_number;
        }

        private void FormWhatsappBulk_FormClosed(object sender, FormClosedEventArgs e)
        {
            wa.Quit();

            FormKeygen objKeygen = (FormKeygen)Application.OpenForms["FormKeygen"];
            if (objKeygen != null)
            {
                objKeygen.Close();
            }

            FormBrowser objBrowser = (FormBrowser)Application.OpenForms["FormBrowser"];
            if (objBrowser != null)
            {
                objBrowser.Close();
            }
            
        }
    }
}

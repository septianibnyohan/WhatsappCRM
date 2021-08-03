using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatsappLib.Helpers;

namespace WhatsappLib
{
    public class AutoResponder
    {
        Whatsapp _wa;
        public void Run(Whatsapp wa)
        {
            Task.Run(() =>
            {
                _wa = wa;
                while (true)
                {
                    try
                    {
                        Thread.Sleep(1000);

                        var unread_elements = _wa.UnreadElements;

                        foreach (var message in unread_elements)
                        {
                            message.Click();

                            var name_span = _wa.NameSpan;
                            var name = name_span.Text;
                            var textbox_element = _wa.TextboxElement;
                            textbox_element.SendKeys("Di tunggu Ya");

                            var send_button = _wa.SendButton;
                            send_button.Click();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogEx(ex);
                    }
                }
            });
        }
    }
}

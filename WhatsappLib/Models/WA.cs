using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Models
{
    public class WA
    {
        public IWebDriver driver;

        string _unread_element = "CxUIE";
        string _name_span = "//div[@class='_3XrHh']";
        string _textbox_element = "._2WovP > ._2S1VP";
        string _send_button = ".\\_35EW6 > span";
        //string _file_menu = ".\\_3TbsN > div > span";
        string _file_menu = ".rAUz7";
        string _file_menu_path = "//div[@id='main']/header/div[3]/div/div[2]/div/span";
        string _image_box = ".bsmJe > .\\_2S1VP";
        string _image_input = ".\\_1exov > .\\_1azEi";
        string _image_input_box = ".\\_1exov input";
        string _send_file_button = ".\\_3hV1n > span";
        string _image_msg = ".bsmJe > .\\_2S1VP";

        public IWebElement ImageMsg
        {
            get
            {
                var name_span = driver.FindElement(By.CssSelector(_image_msg));
                return name_span;
            }
        }


        public IWebElement FileMenu
        {
            get
            {
                //var name_span = driver.FindElement(By.CssSelector(_file_menu));
                var name_span = driver.FindElement(By.XPath(_file_menu_path));
                return name_span;
            }
        }

        public IWebElement ImageInputBox
        {
            get
            {
                var name_span = driver.FindElement(By.CssSelector(_image_input_box));
                return name_span;
            }
        }

        public IWebElement SendFileButton
        {
            get
            {
                var name_span = driver.FindElement(By.CssSelector(_send_file_button));
                return name_span;
            }
        }

        public ICollection<IWebElement> UnreadElements
        {
            get
            {
                var unread_elements = driver.FindElements(By.ClassName(_unread_element));
                return unread_elements;
            }
        }

        public IWebElement NameSpan
        {
            get
            {
                var name_span = driver.FindElement(By.XPath(_name_span));
                return name_span;
            }
        }

        public IWebElement TextboxElement
        {
            get
            {
                var messagebox = driver.FindElement(By.CssSelector(_textbox_element));
                return messagebox;
            }
        }

        public IWebElement SendButton
        {
            get
            {
                var send_button = driver.FindElement(By.CssSelector(_send_button));
                return send_button;
            }
        }
    }
}

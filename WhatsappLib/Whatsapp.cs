using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Sikuli4Net.sikuli_REST;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatsappLib.Helpers;
using WhatsappLib.Models;

namespace WhatsappLib
{
    
    public class Whatsapp : WA
    {
        
        public void Run()
        {
            try
            {
                driver = WebHelper.GetWebDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); //Wait for maximun of 10 seconds if any element is not found
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://web.whatsapp.com");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public void Quit()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(ex);
                throw ex;
            }
        }

        public bool CheckLoggedIn()
        {
            try
            {
                //return driver.FindElement(By.ClassName("_1FTCC")).Displayed;
                //return driver.FindElement(By.ClassName("_1BjNO")).Displayed;
                return driver.FindElement(By.CssSelector("#side")).Displayed;
            }
            catch (Exception e)
            {
                //Debug.Print(e.Message);
                return false;
            }

        }

        public bool SendMessage(string number, string message)
        {
            try
            {
                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + number + "&text=" + Uri.EscapeDataString(message));
                //driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + number);


                //if (IsWANumberValid(number, message))
                // {
                WaitButtonSendMessage();
                //var check = driver.FindElement(By.ClassName("_3M-N-"));
                //check.Click();
                //var messagebox = driver.FindElement(By.ClassName("_3u328"));
                //var messagebox = driver.FindElement(By.CssSelector("._2WovP > ._2S1VP"));
                var messagebox = driver.FindElement(By.CssSelector("._1hRBM > ._1awRl"));
                
                //String ShiftEnter = Keys.Shift + Keys.Enter + Keys.Shift;
                //message = message.Replace("\r\n", ShiftEnter);
                //message = message + Keys.Enter;
                messagebox.SendKeys(Keys.Enter);

                //}
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(ex);
                return false;
            }
            
        }

        private bool IsWANumberValid(string number, string message = "")
        {
            bool isValid = false;
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Wait for maximun of 10 seconds if any element is not found
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + number + "&text=" + Uri.EscapeDataString(message));

                //_3RiLE
                Thread.Sleep(5000);
                //displayed = driver.FindElement(By.ClassName("_3RiLE")).Displayed;
                var check = driver.FindElement(By.ClassName("_2eK7W"));
                check.Click();
            }
            catch(Exception ex)
            {
                isValid = true;
                return isValid;
            }
            

            return isValid;
        }

        public bool CheckButtonSendMessage()
        {
            try
            {
                return driver.FindElement(By.CssSelector("button._3M-N->span")).Displayed;
            }
            catch (Exception e)
            {
                //Debug.Print(e.Message);
                return false;
            }
        }

        public void SendImage(string number, string message, string filepath)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Wait for maximun of 10 seconds if any element is not found
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + number);
                WaitButtonUploadImage();
                //driver.FindElement(By.CssSelector("._2kYeZ > div:nth-child(1) > div:nth-child(2) > div:nth-child(1)")).Click();
                //driver.FindElement(By.CssSelector("input[type='file']")).SendKeys(filepath);
                var file_menu = FileMenu;
                file_menu.Click();
                //var image_input = ImageInputBox;
                var image_input = driver.FindElement(By.CssSelector("input[type='file']"));
                image_input.SendKeys(filepath);

                if (CheckMessagebox())
                {
                    //var messagebox = driver.FindElement(By.CssSelector("._2YgjU > ._3u328"));
                    var messagebox = ImageMsg;
                    String ShiftEnter = Keys.Shift + Keys.Enter + Keys.Shift;
                    message = message.Replace("\r\n", ShiftEnter);
                    message = message + Keys.Enter;
                    messagebox.SendKeys(message);
                }
                else
                {
                    //var btn_send = driver.FindElement(By.ClassName("iA40b"));
                    var btn_send = SendFileButton;
                    btn_send.Click();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void SendImageByPopup(string number, string[] files)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Wait for maximun of 10 seconds if any element is not found
            driver.Navigate().GoToUrl("https://web.whatsapp.com/send?phone=" + number);
            WaitButtonUploadImage();
            driver.FindElement(By.CssSelector("._2kYeZ > div:nth-child(1) > div:nth-child(2) > div:nth-child(1)")).Click();
            Screen sikuliscreen = new Screen();
            String file1 = "\""+ files[0]+ "\"";
            String file2 = "\"" + files[1] + "\"";
            String mutliplefiles = file1 + file2;
            Pattern window_popup_textbox = new Pattern(files[0]);
            Pattern window_openbtn = new Pattern(files[1]);
            sikuliscreen.Wait(window_popup_textbox, 20);
            sikuliscreen.Type(window_popup_textbox, mutliplefiles);
            sikuliscreen.Click(window_openbtn);
            Thread.Sleep(3000);
        }

        public bool CheckMessagebox()
        {
            bool displayed = false;
            try
            {
                //Thread.Sleep(5000);
                //displayed = driver.FindElement(By.CssSelector("._2YgjU > ._3u328")).Displayed;
                displayed = ImageMsg.Displayed;

                //if (displayed) return true;
            }
            catch (Exception e)
            {
                //Debug.Print(e.Message);
                displayed = false;
            }

            return displayed;
        }

        public bool WaitButtonUploadImage()
        {
            bool displayed = false;

            for (int index = 0; index < 6; ++index)
            { 
                try
                {
                    //displayed = driver.FindElement(By.CssSelector("._2kYeZ > div:nth-child(1) > div:nth-child(2) > div:nth-child(1)")).Displayed;
                    displayed = FileMenu.Displayed;

                    if (displayed) return displayed;

                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    //Debug.Print(e.Message);
                    displayed = false;
                }
            }

            return displayed;
        }

        public bool WaitButtonSendMessage()
        {
            bool displayed = false;
            for (int index = 0; index < 3; ++index)
            {
                try
                {
                    //displayed = driver.FindElement(By.ClassName("_3M-N-")).Displayed;
                    //_3u328
                    displayed = driver.FindElement(By.ClassName("_2Ujuu")).Displayed;
                    //Thread.Sleep(5000);

                    if (displayed) break;
                }
                catch (Exception e)
                {
                    //Debug.Print(e.Message);
                    LogHelper.LogEx(e);
                    displayed = false;
                }
            }
            return displayed;
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappLib;

namespace ConfiguringSelenium
{
    class Set_basics
    {
        static void Main(string[] args)
        {
            string test = Keygen.GetSerialNumber().Replace("/","");
            string sha = Keygen.GetSHA1(test);

            Whatsapp wa = new Whatsapp();
            wa.Run();

            while(!wa.CheckLoggedIn()){
                Console.WriteLine("Not login yet");
            }

            Console.WriteLine("Loginned");
            string filepath = @"E:\image\images.png";
            //wa.SendImage("6287883711444", filepath);
            //wa.SendMessage("6287883711444", "Adeeeeek......");
            // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"E:\Project\ConfiguringSelenium\ConfiguringSelenium\bin\Debug", "geckodriver.exe");
            //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            //FirefoxDriver driver = new FirefoxDriver(service);

            /*
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = (@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");

            IWebDriver driver = new FirefoxDriver(options);

            driver.Url = "https://web.whatsapp.com";

            bool test = false;

            try
            {
                while (driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div[1]/div/div[2]/div")) != null)
                {
                    Console.WriteLine("Test aja");
                }
            }
            catch(Exception ex)
            {

            }

            Console.WriteLine("Loginned");

            driver.Url = "https://web.whatsapp.com/send?phone=6282122277700";
            */
        }
    }
}

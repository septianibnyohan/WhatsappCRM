using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappLib.Helpers
{
    enum Browser
    {
        Chrome,
        Firefox
    }

    public class WebHelper
    {
        public static IWebDriver GetWebDriver()
        {
            int webdriver = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["WebDriver"]);

            if (webdriver == (int)Browser.Chrome)
            {
                return new ChromeDriver();
            }
            else if (webdriver == (int)Browser.Firefox)
            {
                return GetFirefoxDriver();
            }

            return GetFirefoxDriver();
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            string firefoxLoc1 = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            string firefoxLoc2 = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            string firefoxLocation = "";


            if (File.Exists(firefoxLoc1))
            {
                firefoxLocation = firefoxLoc1;
            }
            else if (File.Exists(firefoxLoc2))
            {
                firefoxLocation = firefoxLoc2;
            }
            else
            {
                firefoxLocation = System.Configuration.ConfigurationSettings.AppSettings["FirefoxLocation"];
            }

            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = firefoxLocation;

            return new FirefoxDriver(options);
        }
    }
}

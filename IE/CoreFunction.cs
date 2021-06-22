using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IE
{
    class CoreFunction
    {
        //public static object ChromeBrowser = new ChromeDriver();
        
        public static void ChromeNavigate(string url)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

        }

    }
}

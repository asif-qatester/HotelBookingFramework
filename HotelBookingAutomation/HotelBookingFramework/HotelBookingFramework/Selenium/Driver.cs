using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;


namespace HotelBookingFramework
{
    public static class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress
        {
            get { return "http://hotel-test.equalexperts.io/"; }
        }
        public static void Initialize()
        {

            SelectBrowser(BrowserType.Chrome);
            TurnOnWait();
        }
        public static void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            { 
                case BrowserType.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    Instance = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    Instance = new InternetExplorerDriver();
                    break;
                default:
                    break;
            }
        }
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }
        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(0);
        }
        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public static void Close()
        {
            Instance.Close();
        }
    }
}

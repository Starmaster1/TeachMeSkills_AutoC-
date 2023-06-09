﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19_Selenium_WebDriver._Advanced.Core
{
    public class Browser
    {

        private static Browser instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }



        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }

                return instance;
            }
        }

        private Browser()
        {
            //choose browser
            var isHeadless = bool.Parse(TestContext.Parameters.Get("Headless"));
            var wait = int.Parse(TestContext.Parameters.Get("ImplicityWait"));

            if (isHeadless)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("incognito");
                options.AddArgument("--start-maximized");

                driver = new ChromeDriver(options);
            }
            else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void AcceptAllert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void AcceptDismiss()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToFrame(string id)
        {
            driver.SwitchTo().Frame(id);
        }

        public void SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }

        public object ExecuteScript(string scipt, object argument = null)
        {
            try
            {

                return ((IJavaScriptExecutor)driver).ExecuteScript(scipt, argument);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

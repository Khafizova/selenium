﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;


namespace csharp
{
    [TestClass]
    public class Task17

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
          
        }
        public void Log(string value, params object[] values)
        {
            if (!String.IsNullOrEmpty(value) && value.Length > 0 && value.Substring(0, 1) != "*")
            {
                value = "      " + value;
            }
            Console.WriteLine(String.Format(value, values));
        }

        private void CheckLogs()
        {
            List<LogEntry> logs = driver.Manage().Logs.GetLog(LogType.Browser).ToList();
            int NumberOfEntries = logs.Count;
            Console.WriteLine("Number of entries in current log is " + NumberOfEntries);
            foreach (LogEntry log in logs)
            {
                Log(log.Message);
            }
        }

        [Test]

        public void BrowserLogs()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.FindElement(By.CssSelector("ul#box-apps-menu li:nth-of-type(2) > a")).Click();
            driver.FindElement(By.CssSelector("table.dataTable tr.row:nth-of-type(3) td:nth-of-type(3) a")).Click();
            int LinksToClickInTable = driver.FindElements(By.CssSelector("table.dataTable tr.row")).Count;
            for (int i = 3; i < LinksToClickInTable; i++)
            {
                List<IWebElement> ProductsToClick = driver.FindElements(By.CssSelector("table.dataTable tr.row td:nth-of-type(3) a")).ToList();
                ProductsToClick[i].Click();
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("head")));
                Console.WriteLine("Current products is " + (i - 2));
                CheckLogs();
                driver.Navigate().Back();
            }
        }
        
        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
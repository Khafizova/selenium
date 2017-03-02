using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Homework
{
    [TestFixture]
     public class homework14
     {
         private IWebDriver driver;
         private WebDriverWait wait;
 
         [SetUp]
        public void start()
         {
             driver = new ChromeDriver();
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
         }
 
         [Test]
        public void CheckLinksOpenInNewWindow()
         {
             driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
             driver.FindElement(By.Name("username")).SendKeys("admin");
             driver.FindElement(By.Name("password")).SendKeys("admin");
             driver.FindElement(By.Name("login")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sidebar")));
             driver.FindElement(By.CssSelector("a[href*='country_code=AF']")).Click();
             string mainWindow = driver.CurrentWindowHandle;
             ICollection<string> oldWindows;
             ICollection<string> newWindows;
             IList<IWebElement> externalLinks = driver.FindElements(By.CssSelector(".fa.fa-external-link"));
             foreach (IWebElement link in externalLinks)
             {
                 oldWindows = driver.WindowHandles;
                 link.Click();
                 newWindows = driver.WindowHandles;
                 string newWindowHandle = getNewWindowHandle(oldWindows, newWindows);
                 driver.SwitchTo().Window(newWindowHandle);
                 driver.Close();
                 driver.SwitchTo().Window(mainWindow);
             }
 
 
         }
        
         public string getNewWindowHandle(ICollection<string> newWindowHandles, ICollection<string> oldWindowHandles)
         {
             string newWindow = null;
             foreach (string i in oldWindowHandles)
             {
                 if (newWindowHandles.Contains(i))
                 {
                     continue;
                 }
                 else
                 {
                     newWindow = i;
                     break;
                 }
             }
             return newWindow;
 
         }
 
 
         [TearDown]
         public void stop()
         {
             driver.Quit();
             driver = null;
         }
     }
} 
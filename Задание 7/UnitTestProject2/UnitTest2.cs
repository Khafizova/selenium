using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject2
{
    [TestFixture]
     public class homework7
   {
         private IWebDriver driver;
         private WebDriverWait wait;
 
         [SetUp]
         public void start()
         {
             driver = new ChromeDriver();
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
         }
 
         [Test]
         public void MenuNavigation()
         {
             driver.Url = "http://localhost/litecart/admin";
             driver.FindElement(By.Name("username")).SendKeys("admin");
             driver.FindElement(By.Name("password")).SendKeys("admin");
             driver.FindElement(By.Name("login")).Click();
        
             int Items = driver.FindElements(By.CssSelector("li#app-")).Count;
             for (int i = 1; i<=Items; i++)
             {
                 driver.FindElement(By.CssSelector("li#app-:nth-child(" + i + ")")).Click();
                 IWebElement menuItem = driver.FindElement(By.CssSelector("li#app-:nth-child(" + i + ")"));
                 Assert.IsTrue(driver.FindElement(By.CssSelector("#content h1")).Displayed);
                 
                 int SubItems = menuItem.FindElements(By.CssSelector("li")).Count;
                 for (int j = 1; j<=SubItems; j++)
                 {
                    IWebElement subitem = menuItem.FindElement(By.CssSelector("li:nth-child(" + j + ")"));
                    subitem.Click();
                    Assert.IsTrue(driver.FindElement(By.CssSelector("#content h1")).Displayed);
                    menuItem = driver.FindElement(By.CssSelector("li#app-:nth-child(" + i + ")"));
 
                 }
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
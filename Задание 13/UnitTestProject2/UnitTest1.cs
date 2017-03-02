using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace UnitTestProject2
{
    [TestClass]
     public class Task13
 
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
 
         public void WorkingWithBasket()
         {
             driver.Url = "http://localhost/litecart/en/";
             for (int i = 0; i< 3; i++)
                 {
                   if (i <=1)
                 {
                     driver.FindElement(By.CssSelector("div#box-most-popular div.content ul a")).Click();
                     IWebElement CurrentCourtElement = driver.FindElement(By.CssSelector("span.quantity"));
                     int ItemsInTheBasket = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                     if (driver.FindElements(By.CssSelector("select[name*=options]")).Count > 0)
                     {
                         driver.FindElement(By.CssSelector("select[name*=options]")).Click();
                         driver.FindElement(By.CssSelector("select[name*=options] option:nth-of-type(2)")).Click();
                         string SizeValue = driver.FindElement(By.CssSelector("select[name*=options]")).GetAttribute("value");
                         NUnit.Framework.Assert.AreEqual(SizeValue, "Small");
                     }
                     driver.FindElement(By.CssSelector("button[name=add_cart_product]")).Click();
                     string CourtNumber = (i + 1).ToString();
                     wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.quantity"), CourtNumber));
                     int ItemsInTheBasketNew = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                     NUnit.Framework.Assert.AreEqual(ItemsInTheBasket, ItemsInTheBasketNew - 1);
                     driver.Navigate().Back();
                    
                 }
                 else 
                {
                     IWebElement DuckToClick = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title]"));
                     DuckToClick.Click();
                     wait.Until(ExpectedConditions.TitleIs("Yellow Duck | Subcategory | Rubber Ducks | My Store"));
                     IWebElement CurrentCourtElement = driver.FindElement(By.CssSelector("span.quantity"));
                     int ItemsInTheBasket = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                     driver.FindElement(By.CssSelector("select[name*=options]")).Click();
                     driver.FindElement(By.CssSelector("select[name*=options] option:nth-of-type(2)")).Click();
                     string SizeValue = driver.FindElement(By.CssSelector("select[name*=options]")).GetAttribute("value");
                     NUnit.Framework.Assert.AreEqual(SizeValue, "Small");
                     driver.FindElement(By.CssSelector("button[name=add_cart_product]")).Click();
                     string CourtNumber = (i + 1).ToString();
                     wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.quantity"), CourtNumber));
                     int ItemsInTheBasketNew = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                     NUnit.Framework.Assert.AreEqual(ItemsInTheBasket, ItemsInTheBasketNew - 1);
                     driver.Navigate().Back();
                  }
            }
 
             driver.FindElement(By.CssSelector("div#cart a.link")).Click();
             int UniqueItems = driver.FindElements(By.CssSelector("ul.shortcuts li.shortcut")).Count;
 
             for (int i = 0; i<UniqueItems; i++)
             {
                 if (i == UniqueItems-1)
                    {
                     IWebElement LastItemInTheOrder = driver.FindElement(By.CssSelector("div#order_confirmation-wrapper tr:nth-of-type(2) td.item"));
                     driver.FindElement(By.CssSelector("button[name=remove_cart_item]")).Click();
                     wait.Until(ExpectedConditions.StalenessOf(LastItemInTheOrder));
                    }
                 else {
                     IWebElement LastItemInTheOrder = driver.FindElement(By.CssSelector("div#order_confirmation-wrapper tr:nth-of-type(2) td.item"));
                     driver.FindElement(By.CssSelector("ul.shortcuts li.shortcut:nth-of-type(1) a")).Click();
                     driver.FindElement(By.CssSelector("button[name=remove_cart_item]")).Click();
                     wait.Until(ExpectedConditions.StalenessOf(LastItemInTheOrder));
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
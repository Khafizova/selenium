using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestFixture]
     public class homework12
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
         public void RegisterNewProduct()
         {
             driver.Url = "http://localhost/litecart/admin";
             driver.FindElement(By.Name("username")).SendKeys("admin");
             driver.FindElement(By.Name("password")).SendKeys("admin");
             driver.FindElement(By.Name("login")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("sidebar")));
             driver.FindElement(By.CssSelector("a[href*=catalog]")).Click();
             wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".button[href*=edit_product]")));
             driver.FindElement(By.CssSelector(".button[href*=edit_product]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tab-general")));
             driver.FindElement(By.CssSelector("input[type='radio'][name='status'][value='1']")).Click();
             Random rnd = new Random();
             string code = rnd.Next(10000).ToString();
             string productName = "Product" + code;
             driver.FindElement(By.CssSelector("input[name*=name]")).SendKeys(productName);
             driver.FindElement(By.CssSelector("input[name=code]")).SendKeys(code);
             driver.FindElement(By.CssSelector("input[type=checkbox][data-name='Rubber Ducks']")).Click();
             driver.FindElement(By.CssSelector("input[type=checkbox][name='product_groups[]'][value='1-2']")).Click();
             driver.FindElement(By.CssSelector("input[name=quantity]")).Clear();
             driver.FindElement(By.CssSelector("input[name=quantity]")).SendKeys("5");
             SelectElement quantityUnit = new SelectElement(driver.FindElement(By.CssSelector("select[name=quantity_unit_id]")));
             quantityUnit.SelectByText("pcs");
             SelectElement deliveryStatus = new SelectElement(driver.FindElement(By.CssSelector("select[name=delivery_status_id]")));
             deliveryStatus.SelectByText("3-5 days");
             SelectElement soldOutStatus = new SelectElement(driver.FindElement(By.CssSelector("select[name=sold_out_status_id]")));
             soldOutStatus.SelectByText("-- Select --");
             driver.FindElement(By.CssSelector("input[name=date_valid_from]")).SendKeys("20170301");
             driver.FindElement(By.CssSelector("input[name=date_valid_to]")).SendKeys("20170331");
             driver.FindElement(By.CssSelector("a[href='#tab-information']")).Click();
             driver.FindElement(By.CssSelector("input[name=keywords]")).SendKeys("duck");
             driver.FindElement(By.CssSelector("input[name*=short_description]")).SendKeys("product short description");
             driver.FindElement(By.CssSelector("textarea[name*=description]")).SendKeys("product full description");
             driver.FindElement(By.CssSelector("input[name*=head_title]")).SendKeys("product head title");
             driver.FindElement(By.CssSelector("input[name*=meta_description]")).SendKeys("product meta");
             driver.FindElement(By.CssSelector("a[href='#tab-prices']")).Click();
             driver.FindElement(By.CssSelector("input[name=purchase_price]")).Clear();
             driver.FindElement(By.CssSelector("input[name=purchase_price]")).SendKeys("5");
             SelectElement currency = new SelectElement(driver.FindElement(By.CssSelector("select[name=purchase_price_currency_code]")));
             currency.SelectByText("Euros");
             driver.FindElement(By.CssSelector("input[name='prices[USD]']")).SendKeys("10");
             driver.FindElement(By.CssSelector("input[name='prices[EUR]']")).SendKeys("8");
             
             driver.FindElement(By.CssSelector("button[name=save]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dataTable")));
             IList<IWebElement> products = driver.FindElements(By.CssSelector(".dataTable .row td:nth-child(3) a"));
             bool p = false;
             foreach (IWebElement i in products)
             {
                 if (i.GetAttribute("textContent") == productName)
                 {
                     p = true;
                 } 
             }
              Assert.IsTrue(p);
          }
 
         [TearDown]
         public void stop()
         {
             driver.Quit();
            driver = null;
        }
     }
 } 
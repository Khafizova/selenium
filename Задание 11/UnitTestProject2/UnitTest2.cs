using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject2
{
    [TestFixture]
     public class homework11
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
        public void RegisterNewCustomer()
         {
             driver.Url = "http://localhost/litecart";
             driver.FindElement(By.CssSelector("a[href*=create_account]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("form[name=customer_form]")));
             
             Random rnd = new Random();
             string email = "mail" + rnd.Next(1000) + "@test.mail";
             
             driver.FindElement(By.CssSelector("input[name=firstname]")).SendKeys("MyFirstName");
             driver.FindElement(By.CssSelector("input[name=lastname]")).SendKeys("MyLastName");
             driver.FindElement(By.CssSelector("input[name=address1]")).SendKeys("MyAddress");
             driver.FindElement(By.CssSelector("input[name=postcode]")).SendKeys("11111");
             driver.FindElement(By.CssSelector("input[name=city]")).SendKeys("MyCity");
             SelectElement country = new SelectElement(driver.FindElement(By.CssSelector("select[name=country_code]")));
             country.SelectByText("United States");
             wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("select[name=zone_code]")));
             SelectElement zone = new SelectElement(driver.FindElement(By.CssSelector("select[name=zone_code]")));
             zone.SelectByText("Alabama");
             driver.FindElement(By.CssSelector("input[name=email]")).SendKeys(email);
             driver.FindElement(By.CssSelector("input[name=phone]")).SendKeys("12345678");
             driver.FindElement(By.CssSelector("input[name=password]")).SendKeys("password");
             driver.FindElement(By.CssSelector("input[name=confirmed_password]")).SendKeys("password");
             driver.FindElement(By.CssSelector("button[name=create_account]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*=logout]")));
          
             driver.FindElement(By.CssSelector("a[href*=logout]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[name=login]")));
             
             driver.FindElement(By.CssSelector("input[name=email]")).Clear();
             driver.FindElement(By.CssSelector("input[name=email]")).SendKeys(email);
             driver.FindElement(By.CssSelector("input[name=password]")).Clear();
             driver.FindElement(By.CssSelector("input[name=password]")).SendKeys("password");
             driver.FindElement(By.CssSelector("button[name=login]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[href*=logout]")));
       
             driver.FindElement(By.CssSelector("a[href*=logout]")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button[name=login]")));
         }
 
         [TearDown]
         public void stop()
         {
             driver.Quit();
             driver = null;
         }
     }
} 
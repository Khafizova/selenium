using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestFixture]
    public class homework8
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
    public void VerifyProductStickers()
    {
        driver.Url = "http://localhost/litecart";
        IList<IWebElement> products = driver.FindElements(By.CssSelector("li.product.column.shadow.hover-light"));
        foreach (IWebElement i in products)
        {
            Assert.IsTrue(i.FindElements(By.CssSelector(".sticker")).Count == 1);
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
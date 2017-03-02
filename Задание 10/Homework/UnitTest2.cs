using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        [TestMethod]
        public void CheckOpeningCorrectProductPage()
        {
            driver.Url = "http://localhost/litecart/";
            string campaingsProductsSelector = "#box-campaigns ul";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(campaingsProductsSelector)));

            var firstCampaingsProduct = driver.FindElement(By.CssSelector(campaingsProductsSelector + " li:first-of-type"));
            string name = firstCampaingsProduct.FindElement(By.CssSelector(".name")).Text;

            var regularPrice = firstCampaingsProduct.FindElement(By.CssSelector(".regular-price"));
            string regularPriceText = regularPrice.Text;
            string regularPriceColor = regularPrice.GetCssValue("color");
            string regularPriceTextDecoration = regularPrice.GetCssValue("text-decoration");
            string regularPriceFontSize = regularPrice.GetCssValue("font-size");

            var campaignPrice = firstCampaingsProduct.FindElement(By.CssSelector(".campaign-price"));
            string campaignPriceText = campaignPrice.Text;
            string campaignPriceColor = campaignPrice.GetCssValue("color");
            string campaignPriceTextDecoration = campaignPrice.GetCssValue("text-decoration");
            string campaignPriceFontSize = campaignPrice.GetCssValue("font-size");

            firstCampaingsProduct.FindElement(By.CssSelector("a.link")).Click();
            string productPageInfoSelector = "#box-product";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(productPageInfoSelector)));
            var productPageInfo = driver.FindElement(By.CssSelector(productPageInfoSelector));
            string productPageName = productPageInfo.FindElement(By.CssSelector("h1.title")).Text;

            var productPageRegularPrice = productPageInfo.FindElement(By.CssSelector(".regular-price"));
            string productPageRegularPriceText = productPageRegularPrice.Text;
            string productPageRegularPriceColor = productPageRegularPrice.GetCssValue("color");
            string productPageRegularPriceTextDecoration = productPageRegularPrice.GetCssValue("text-decoration");
            string productPageRegularPriceFontSize = productPageRegularPrice.GetCssValue("font-size");

            var productPageCampaignPrice = productPageInfo.FindElement(By.CssSelector(".campaign-price"));
            string productPageCampaignPriceText = productPageCampaignPrice.Text;
            string productPageCampaignPriceColor = productPageCampaignPrice.GetCssValue("color");
            string productPageCampaignPriceTextDecoration = productPageCampaignPrice.GetCssValue("text-decoration");
            string productPageCampaignPriceFontSize = productPageCampaignPrice.GetCssValue("font-size");

            Assert.AreEqual(name, productPageName, "Названия товара на страницах отличаются!", name, productPageName);

            string expectedRegularPriceColor = "rgba(119, 119, 119, 1)";
            string expectedProductPageRegularPriceColor = "rgba(102, 102, 102, 1)";
            string expectedRegularPriceTextDecoration = "line-through";
            string expectedRegularPriceFontSize = "14.4px";
            string expectedProductPageRegularPriceFontSize = "16px";

            Assert.AreEqual(regularPriceText, productPageRegularPriceText, "Значения обычной цены товара на страницах отличаются!", regularPriceText, productPageRegularPriceText);
            Assert.AreEqual(regularPriceColor, expectedRegularPriceColor, "Цвета обычной цены товара на главной странице отличаются!", regularPriceColor, expectedRegularPriceColor);
            Assert.AreEqual(productPageRegularPriceColor, expectedProductPageRegularPriceColor, "Цвета обычной цены товара на его странице отличаются!", productPageRegularPriceColor, expectedProductPageRegularPriceColor);
            Assert.AreEqual(regularPriceTextDecoration, expectedRegularPriceTextDecoration, "Стили обычной цены товара на главной странице отличаются!", regularPriceTextDecoration, expectedRegularPriceTextDecoration);
            Assert.AreEqual(productPageRegularPriceTextDecoration, expectedRegularPriceTextDecoration, "Стили обычной цены товара на его странице отличаются!", productPageRegularPriceTextDecoration, expectedRegularPriceTextDecoration);
            Assert.AreEqual(regularPriceFontSize, expectedRegularPriceFontSize, "Размеры обычной цены товара на главной странице отличаются!", regularPriceFontSize, expectedRegularPriceFontSize);
            Assert.AreEqual(productPageRegularPriceFontSize, expectedProductPageRegularPriceFontSize, "Размеры обычной цены товара на его странице отличаются!", regularPriceFontSize, expectedProductPageRegularPriceFontSize);


            string expectedCampaignPriceColor = "rgba(204, 0, 0, 1)";
            string expectedProductPageCampaignPriceColor = "rgba(204, 0, 0, 1)";
            string expectedCampaignPriceTextDecoration = "none";
            string expectedCampaignPriceFontSize = "18px";
            string expectedProductPageCampaignPriceFontSize = "22px";

            Assert.AreEqual(campaignPriceText, productPageCampaignPriceText, "Значения цены товара по акции на страницах отличаются!", campaignPriceText, productPageCampaignPriceText);
            Assert.AreEqual(campaignPriceColor, expectedCampaignPriceColor, "Цвета цены товара по акции на главной странице отличаются!", campaignPriceColor, expectedCampaignPriceColor);
            Assert.AreEqual(productPageCampaignPriceColor, expectedProductPageCampaignPriceColor, "Цвета цены товара по акции на его странице отличаются!", productPageCampaignPriceColor, expectedProductPageCampaignPriceColor);
            Assert.AreEqual(campaignPriceTextDecoration, expectedCampaignPriceTextDecoration, "Стили цены товара по акции на главной странице отличаются!", campaignPriceTextDecoration, expectedCampaignPriceTextDecoration);
            Assert.AreEqual(productPageCampaignPriceTextDecoration, expectedCampaignPriceTextDecoration, "Стили цены товара по акции на его странице отличаются!", productPageCampaignPriceTextDecoration, expectedCampaignPriceTextDecoration);
            Assert.AreEqual(campaignPriceFontSize, expectedCampaignPriceFontSize, "Размеры цены товара по акции на главной странице отличаются!", campaignPriceFontSize, expectedCampaignPriceFontSize);
            Assert.AreEqual(productPageCampaignPriceFontSize, expectedProductPageCampaignPriceFontSize, "Размеры цены товара по акции на его странице отличаются!", productPageCampaignPriceFontSize, expectedProductPageCampaignPriceFontSize);
        }

        [TestCleanup]
        public void Finish()
        {
            driver.Quit();
            driver = null;
        }
    }
}
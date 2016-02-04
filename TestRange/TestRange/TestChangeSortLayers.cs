using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Threading;
namespace TestRange
{
    /// <summary>
    /// Осуществляет проверку на изменение порядка отображения слоев.
    /// </summary>
    [TestClass]
    public class TestChangeSortLayers
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        private string zIndexDNS;
        private string zIndexFakel;
        private string zIndexAmbar;
        private string zIndexPlaces;
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        private const string loginUrl = "http://91.143.44.249/sovzond_test/portal/";
        private const string locationLegenda = "#menuSlide div.svzSimpleButton.slidePanelLegendButton";
        private const string locationIncDNS = "#dojoUnique4 img";
        private const string locationIncFakel = "#dojoUnique1 img";
        private const string locationIncAmbar = "#dojoUnique2 img";
        private const string locationIncPlaces = "#dojoUnique3 img";

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            js = driver as IJavaScriptExecutor;
            zIndexDNS = "";
            zIndexFakel = "";
            zIndexAmbar = "";
            zIndexPlaces = "";
        }

        /// <summary>
        ///Перемещает каждый последний слой на позицию первого.
        ///</summary>
        [TestMethod]
        public void IncrementLayers()
        {
            LogOn();
            IncrementLayerDNS();
            IncrementLayerPlaces();
            IncrementLayerAmbar();
            IncrementLayerFakel();
        }
        [TestCleanup]
        public void Clean()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
        private void LogOn()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
            Assert.AreEqual(loginUrl, driver.Url, "Не удалось пройти авторизацию");
        }
        private void IncrementLayerDNS()
        {
            driver.FindElement(By.CssSelector(locationLegenda)).Click();
            zIndexFakel = (string)js.ExecuteScript("return window.portal.stdmap.map.getLayersByName(\"wms_Факелы\")[0].div.style.zIndex;");
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.CssSelector(locationIncDNS)).Click();
            zIndexDNS = (string)js.ExecuteScript("return window.portal.stdmap.map.getLayersByName(\"wms_ДНС\")[0].div.style.zIndex;");
            Assert.AreEqual(zIndexFakel, zIndexDNS, "Слой не отобразился выше предыдущего");
            Thread.Sleep(1000);
        }
        private void IncrementLayerPlaces()
        {
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.CssSelector(locationIncPlaces)).Click();
            zIndexPlaces = (string)js.ExecuteScript("return window.portal.stdmap.map.getLayersByName(\"wms_Кустовые площадки\")[0].div.style.zIndex;");
            Assert.AreEqual(zIndexDNS, zIndexPlaces, "Слой не отобразился выше предыдущего");
            Thread.Sleep(1000);
        }
        private void IncrementLayerAmbar()
        {
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.CssSelector(locationIncAmbar)).Click();
            zIndexAmbar = (string)js.ExecuteScript("return window.portal.stdmap.map.getLayersByName(\"wms_Амбары\")[0].div.style.zIndex;");
            Assert.AreEqual(zIndexPlaces, zIndexAmbar, "Слой не отобразился выше предыдущего");
            Thread.Sleep(1000);
        }
        private void IncrementLayerFakel()
        {
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.CssSelector(locationIncFakel)).Click();
            zIndexFakel = (string)js.ExecuteScript("return window.portal.stdmap.map.getLayersByName(\"wms_Факелы\")[0].div.style.zIndex;");
            Assert.AreEqual(zIndexPlaces, zIndexFakel, "Слой не отобразился выше предыдущего");
            Thread.Sleep(1000);
        }
    }
}

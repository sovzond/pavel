using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
namespace TestRange
{
    /// <summary>
    ///  
    /// </summary>
    [TestClass]
    public class TestBaseLayers
  
    {

        private IWebDriver driver;
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        private const string loginUrl = "http://91.143.44.249/sovzond_test/portal/";
        
        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();

        }
        /// <summary>
        ///
        ///</summary>
        [TestMethod]
        public void CheckBaseLayers()
         {
            
            LogOn();
            CheckGoogleLayers();
 
        }
        [TestCleanup]
        public void Clean()
        {
            System.Threading.Thread.Sleep(2000);
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
        private void CheckGoogleLayers()
        {

              driver.FindElement(By.Id("menuSlide")) 
                   .FindElement(By.CssSelector("div.svzSimpleButton.slidePanelButton")).Click(); // открыть плажку       
               IWebElement elementBaseLayer = driver.FindElement(By.Id("layersCon"))
                   .FindElement(By.CssSelector("div.svzSimpleButton.accordionButton"));
               var builderBaseLayers = new Actions(driver);
               System.Threading.Thread.Sleep(1000);
               builderBaseLayers.Click(elementBaseLayer).Perform(); // открыть базовые слои
            System.Threading.Thread.Sleep(1000);
            IWebElement elementOSM = driver.FindElement(By.XPath("//input[@aria-checked='true']"));
            int osmX = 3;
            int osmY = 232;
            Assert.AreEqual(osmX, elementOSM.Location.X, "Базовый слой OpenStreetMap отключен");
            Assert.AreEqual(osmY, elementOSM.Location.Y, "Базовый слой OpenStreetMap отключен");
            driver.FindElement(By.Id("stdportal_LayerManagerBase_0"))
                .FindElement(By.CssSelector("div.svzLayerManagerText")).Click(); // открыть гугл
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("dijit_form_RadioButton_1")).Click(); // открыть спутник
            driver.FindElement(By.Id("stdportal_LayerManagerBase_0"))
                .FindElement(By.CssSelector("input.dijitReset.dijitCheckBoxInput")).Click(); // открыть схема

         /*   IWebElement elementLayerScheme = driver.FindElement(By.Id("stdportal_LayerManagerBase_0"))
                .FindElement(By.CssSelector("input.dijitReset.dijitCheckBoxInput"));
            var builderLayerScheme = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
            builderLayerScheme.Click(elementLayerScheme).Perform();
            */

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string idScheme = (string)js.ExecuteScript("return window.portal.stdmap.map.baseLayer.div.id.toString()");
            IWebElement e1 = driver.FindElement(By.Id(idScheme));
            IList <IWebElement> elementScheme = driver
                //.FindElements(By.CssSelector("#" + idScheme + " img"));
                .FindElements(By.CssSelector("div.gm-style img[src*='google']"));
           
            List <string> names = new List<string>();
            foreach (IWebElement el in elementScheme)
            {
                string src = el.GetAttribute("src");
                names.Add(src);

            }
            /*  System.Threading.Thread.Sleep(2000);
              driver.FindElement(By.Id("dijit_form_RadioButton_1")).Click();  // открыть спутник
              System.Threading.Thread.Sleep(2000);
              driver.FindElement(By.Id("dijit_form_RadioButton_2")).Click(); // открыть клик
              */
            //dojo.query("div.gm-style img[src*=google]")[1]); - возвращает тег img гугловской картинки
            //window.portal.stdmap.map.baseLayer.div.id
            //Возвращаят id контейнера в котором следует искать картинку для сравнения.
            //найти необходимую картинку для сравнения

            //Логика: выбрать слой, найти картинку этого слоя. Сравни, появилась ли эта картинка после отображения слоя.

        }

    }
}

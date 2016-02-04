using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using Interface;
namespace TestRange
{
    /// <summary>
    ///Выполняет проверку на отображение слоев гугл, а так же на автоматическое включение  слоя OpenStreetMap  
    /// </summary>
    [TestClass]
    public class TestBaseLayers
    {
        private IWebDriver driver;
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        private const string loginUrl = "http://91.143.44.249/sovzond_test/portal/";
        private const string urlImageScheme = "http://maps.googleapis.com/maps/api/js/StaticMapService.GetMapImage?1m2&1i363301&2i149508&2e1&3u11&4m2&1u1426&2u595&5m5&1e0&5sru-RU&6sus&10b1&12b1&token=21311";
        private const string urlImageSputnik = "http://maps.googleapis.com/maps/api/js/StaticMapService.GetMapImage?1m2&1i363301&2i149508&2e2&3u11&4m2&1u1426&2u595&5m5&1e2&5sru-RU&6sus&10b1&12b1&token=32241";
        private const string urlImageGibrid = "http://maps.googleapis.com/maps/api/js/StaticMapService.GetMapImage?1m2&1i363301&2i149508&2e2&3u11&4m2&1u1426&2u595&5m5&1e3&5sru-RU&6sus&10b1&12b1&token=98410";
        private const string locationSlideMenu = "#menuSlide div.svzSimpleButton.slidePanelButton";
        private const string locationBaseLayers = "#layersCon div.svzSimpleButton.accordionButton";
        private const string locationBaseLayersChildContainer = "layerManagerBasemap";
        private const string locationRadioButtonOSM = "#layerManagerBasemap div.dijit.dijitReset.dijitInline.dijitRadio.dijitRadioChecked.dijitChecked input";
        private const string locationGoogle = "#stdportal_LayerManagerBase_0 div.svzLayerManagerText";
        private const string locationLayerSputnik = "dijit_form_RadioButton_1";
        private const string locationLayerScheme = "#stdportal_LayerManagerBase_0 input.dijitReset.dijitCheckBoxInput";
        private const string locationLayerGibrid = "dijit_form_RadioButton_2";

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }

        /// <summary>
        ///Выполняет проверку на отображение слоев гугл, а так же на автоматическое включение  слоя OpenStreetMap
        ///</summary>
        [TestMethod]
        public void CheckBaseLayers()
        {
            LogOn();
         
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
            MenuNavigation.get(driver).FullExtentButton().GotoCoordsButton().IdentificationButton().MagnifyButton().MoveButton().RuleButton().SelectionButton().ZoomArea();              
        }
        private void OpenBaseLayers()
        { 
            driver.FindElement(By.CssSelector(locationSlideMenu)).Click();    
            IWebElement elementBaseLayer = driver.FindElement(By.CssSelector(locationBaseLayers));
            var builderBaseLayers = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
            builderBaseLayers.Click(elementBaseLayer).Perform(); 
            System.Threading.Thread.Sleep(1000);
        }
        private void CheckSelectedOSM()
        {     
            IWebElement elementRadioButtonTrue = driver.FindElement(By.Id(locationBaseLayersChildContainer)).
              FindElement(By.XPath("//input[@aria-checked='true']")); 
            IWebElement elementOSM = driver.FindElement(By.CssSelector(locationRadioButtonOSM)); 
            Assert.AreEqual(elementOSM.Location.X, elementRadioButtonTrue.Location.X, "Базовый слой OpenStreetMap отключен");
            Assert.AreEqual(elementOSM.Location.Y, elementRadioButtonTrue.Location.Y, "Базовый слой OpenStreetMap отключен"); 
        }
        private void OpenGoogle()
        {
            driver.FindElement(By.CssSelector(locationGoogle)).Click(); 
            System.Threading.Thread.Sleep(1000);
        }
        private void CheckLayerScheme()
        {
            driver.FindElement(By.Id(locationLayerSputnik)).Click();
            driver.FindElement(By.CssSelector(locationLayerScheme)).Click(); 
            System.Threading.Thread.Sleep(1000);
            IList<IWebElement> elementScheme = driver.FindElements(By.CssSelector("div.gm-style img[src*='google']"));
            Assert.AreEqual(urlImageScheme, elementScheme[0].GetAttribute("src"), "Слой схема отобразил не корректный слой.");
        }
        private void CheckLayerSputnik()
        {
            driver.FindElement(By.Id(locationLayerSputnik)).Click();
            System.Threading.Thread.Sleep(1000);
            IList<IWebElement> elementSputnik = driver.FindElements(By.CssSelector("div.gm-style img[src*='google']"));
            Assert.AreEqual(urlImageSputnik, elementSputnik[0].GetAttribute("src"), "Слой спутник отобразил не корректный слой");
        }
        private void CheckLayerGibrid()
        {
            driver.FindElement(By.Id(locationLayerGibrid)).Click();
            System.Threading.Thread.Sleep(1000);
            IList<IWebElement> elementGibrid = driver.FindElements(By.CssSelector("div.gm-style img[src*='google']"));
            Assert.AreEqual(urlImageGibrid, elementGibrid[0].GetAttribute("src"), "Слой гибрид отобразил не корректный слой");
        }

    }
}
namespace Interface
{
    /// <summary>
    /// Открывает плажку в левой части экрана (Слои, Легенда). 
    /// Так же открывает вкладки данной плажки.
    /// </summary>
    public class SlideMenu
    {
        private IWebDriver driver;
        private const string locationSlideMenu = "#menuSlide div.svzSimpleButton.slidePanelButton";
        private const string locationBaseLayers = "#layersCon div.svzSimpleButton.accordionButton";
        private const string locationGoogle = "#stdportal_LayerManagerBase_0 div.svzLayerManagerText";
        private const string locationLegenda = "#menuSlide div.svzSimpleButton.slidePanelLegendButton";
        private SlideMenu(IWebDriver driver)
        {
            this.driver = driver;
        }
        /// <summary>
        /// Принимает параметр типа IWebDriver для дальнейшей навигации по сайту.
        /// </summary>
        /// <param name="driver">Передает аргумент для закрытого конструктора</param>
        /// <returns></returns>
        public static SlideMenu get(IWebDriver driver)
        {
            return new SlideMenu(driver);
        }
        /// <summary>
        /// Открывает базовые слои вкладки 'СЛОИ'.
        /// </summary>
        /// <returns></returns>
        public SlideMenu OpenBaseLayers()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationSlideMenu)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationBaseLayers)).Click();
            return this; 
        }
        /// <summary>
        /// Открывает владку 'Google' во вкладке 'Базовые слои'.
        /// </summary>
        /// <returns></returns>
        public SlideMenu OpenGoogle()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationSlideMenu)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationBaseLayers)).Click();
            driver.FindElement(By.CssSelector(locationGoogle)).Click();
            return this;
        }
        /// <summary>
        /// Открывает вкладку 'Легенда' на плажке в левой части экрана.
        /// </summary>
        /// <returns></returns>
        public SlideMenu OpenLegenda()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationLegenda)).Click();
            return this;
        }

    }
    /// <summary>
    /// Выполняет клик по кнопкам рядом с плажкой (Кнопки DOP).
    /// </summary>
    public class MenuDop
    {
        private IWebDriver driver;
        private const string locationLinks = "#menuDop div.svzSimpleButton.linkBtn";
        private const string locationPrint = "#menuDop div.svzSimpleButton.printBtn";
        private MenuDop(IWebDriver driver)
        {
            this.driver = driver;
        }
        /// <summary>
        /// Принимает параметр типа IWebDriver для дальнейшей навигации по сайту.
        /// </summary>
        /// <param name="driver">Передает аргумент для закрытого конструктора</param>
        /// <returns></returns>
        public static MenuDop get(IWebDriver driver)
        {
            return new MenuDop(driver);
        }
        /// <summary>
        /// Выполняет клик по кнопке 'Ссылки' в верхней левой части экрана. 
        /// </summary>
        /// <returns></returns>
        public MenuDop OpenLinks()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationLinks)).Click();
            return this;
        }
        /// <summary>
        /// Выполняет клик по кнопке 'Печать' в верхней левой части экрана.
        /// </summary>
        /// <returns></returns>
        public MenuDop OpenPrint()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationPrint)).Click();
            return this;
        }
    }
    /// <summary>
    /// Выполянет клик по кнопкам изменяющим масштаб карты в правой верхней части экрана.
    /// </summary>
    public class ScaleMenu
    {
        private IWebDriver driver;
        private const string locationIncrementButton = "#menuIncrement div.svzSimpleButton.zoomIncrement";
        private const string locationDecrementButton = "#menuIncrement div.svzSimpleButton.zoomDecrement";
        private ScaleMenu(IWebDriver driver)
        {
            this.driver = driver;
        }
        /// <summary>
        /// Принимает параметр типа IWebDriver для дальнейшей навигации по сайту.
        /// </summary>
        /// <param name="driver">Передает аргумент для закрытого конструктора</param>
        /// <returns></returns>
        public static ScaleMenu get(IWebDriver driver)
        {
            return new ScaleMenu(driver);
        }
        /// <summary>
        /// Выполняет клик по кнопке 'Приблежение'.
        /// </summary>
        /// <returns></returns>
        public ScaleMenu IncrementButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationIncrementButton)).Click();
            return this;
        }
        /// <summary>
        /// Выполняет клик по кнопке 'Отдаление'.
        /// </summary>
        /// <returns></returns>
        public ScaleMenu DecrementButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationDecrementButton)).Click();
            return this;
        }
    }
    public class MenuNavigationHistory
    {
        private IWebDriver driver;
        private const string locationBackButton = "#menuNavigationHistory div.svzSimpleButton.previousState";
        private const string locationNextButton = "menuNavigationHistory div.svzSimpleButton.nextState";
        private MenuNavigationHistory(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static MenuNavigationHistory get(IWebDriver driver)
        {
            return new MenuNavigationHistory(driver);
        }
        public MenuNavigationHistory Back()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationBackButton)).Click();
            return this;
        } 
        public MenuNavigationHistory Next()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationNextButton)).Click();
            return this;
        }
    }
    public class MenuNavigation
    {
        private IWebDriver driver;
        private const string locationFullExtentButton = "#menuNavigation div.svzSimpleButton.fullMap";
        private const string locationMoveButton = "#menuNavigation div.svzSimpleButton.pan";
        private const string locationZoomAreaButton = "#menuNavigation div.svzSimpleButton.zoomIn";
        private const string locationMagnifyButton = "#menuNavigation div.svzSimpleButton.zoomIn";
        private const string locationIdentificationButton = "#menuNavigation div.svzSimpleButton.searchMap";
        private const string locationSelectionButton = "#menuNavigation div.svzSimpleButton.searchMap";
        private const string locationRuleButton = "#menuNavigation div.svzSimpleButton.measureButton";
        private const string locationGotoCoordsButton = "#menuNavigation div.svzSimpleButton.gotoCoordsButton";
        private MenuNavigation(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static MenuNavigation get(IWebDriver driver)
        {
            return new MenuNavigation(driver);
        }
        public MenuNavigation FullExtentButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationFullExtentButton)).Click();
            return this;
        }
        public MenuNavigation MoveButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationMoveButton)).Click();
            return this;
        }
        public MenuNavigation ZoomArea()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationZoomAreaButton)).Click();
            return this;
        }
        public MenuNavigation MagnifyButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationMagnifyButton)).Click();
            return this;
        }
        public  MenuNavigation IdentificationButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationIdentificationButton)).Click();
            return this;
        }
        public MenuNavigation SelectionButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationSelectionButton)).Click();
            return this;
        }
        public MenuNavigation RuleButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationRuleButton)).Click();
            return this;
        }
        public MenuNavigation GotoCoordsButton()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(locationGotoCoordsButton)).Click();
            return this;
        }
        public MenuNavigation SetLon(int degrees, int minutes, int seconds)
        {
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys(degrees.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys(minutes.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys(seconds.ToString());
            return this;
        }
        public MenuNavigation SetLat(int degrees, int minutes, int seconds)
        {
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys(degrees.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys(minutes.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys(seconds.ToString());
            driver.FindElement(By.CssSelector("#gotoCoords .button")).Click();
            return this;
        }
    }
}
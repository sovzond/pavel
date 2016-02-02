using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace TestRange
{
    /// <summary>
    /// Осуществляет работу с экстентом, проводит сравнивание экстентов.
    /// </summary>
    [TestClass]
    public class TestCurrentExtent
    {
        private IWebDriver driver;
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        private const string loginUrl = "http://91.143.44.249/sovzond_test/portal/";
        private const string locationButtonXY = "#menuNavigation div.svzSimpleButton.gotoCoordsButton";
        private const string locationButtonLinks = "#menuDop div.svzSimpleButton.linkBtn";
        private const string locationTextArea = "#linkExtent textarea";

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
        }
        /// <summary>
        ///Проверяет отображение окна "Ссылка" и осуществляет сравнение экстентов.
        ///</summary>
        [TestMethod]
        public void CheckExtent()
        {
            LogOn();
            MoveExtent();
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

        private void MoveExtent()
        {
            driver.FindElement(By.CssSelector(locationButtonXY)).Click();
            InputCoordWnd.get(driver).setLon(60, 50, 50).setLat(60, 50, 50).Click();
            driver.FindElement(By.CssSelector(locationButtonLinks)).Click();
            IWebElement elementTextArea = driver.FindElement(By.CssSelector(locationTextArea));
            string fullLink = elementTextArea.Text;
            int idxExtentCoords = fullLink.IndexOf('=');
            idxExtentCoords++;
            string onlyExtentCoords = fullLink.Substring(idxExtentCoords);
            string[] splitedExtentCoords = onlyExtentCoords.Split(',');
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string onlyExtentCoordsCurrent = (string)js.ExecuteScript("return window.portal.stdmap.map.getExtent().toString()");
            string[] splitedExtentCoordsCurrent = onlyExtentCoordsCurrent.Split(',');
            for (int i = 0; i < 4; i++)
                Assert.AreEqual(splitedExtentCoordsCurrent[i], splitedExtentCoords[i], "Текущий экстент карты не является корректным");
        }
    }
    public class InputCoordWnd
    {
        private IWebDriver driver;

        private InputCoordWnd(IWebDriver driver)
        {
            this.driver = driver;
        }

        static public InputCoordWnd get(IWebDriver driver)
        {
            driver.FindElement(By.ClassName("gotoCoordsButton")).Click();
            return new InputCoordWnd(driver);
        }

        public InputCoordWnd setLon(int degrees, int minutes, int seconds)
        {
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys(degrees.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys(minutes.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys(seconds.ToString());
            return this;
        }

        public InputCoordWnd setLat(int degrees, int minutes, int seconds)
        {
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys(degrees.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys(minutes.ToString());
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys(seconds.ToString());
            return this;
        }

        public void Click()
        {
            driver.FindElement(By.CssSelector("#gotoCoords .button")).Click();
        }
    }


}

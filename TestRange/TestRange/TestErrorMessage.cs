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
    /// Данный тест осуществляет проверку на ввод символов в ячейку для поиска координат.
    /// </summary>
    [TestClass]
    public class TestErrorMessage
    {
        //Тесты выполнены.
        private IWebDriver driver;     
        private const string charError = "Указано недопустимое значение.";
        private const string intError = "Это значение вне диапазона.";
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        private const string loginUrl = "http://91.143.44.249/sovzond_test/portal/";

        [TestInitialize]
        public void Setup()
        {
            
            driver = new FirefoxDriver();

        }

        /// <summary>
        ///Данный метод проводит проверку на наличае всплывающего окна при вводе цифры привышающей диапазон.
        ///</summary>
        [TestMethod]
        public void TestInt()
        {
            LogOn();
            InputInt();
            //Тест №2
        }

        /// <summary>
        ///Данный метод проводит проверку на наличае всплывающего окна при вводе недопустимого значение.
        ///</summary>
        [TestMethod]
        public void TestChar()
        {
            LogOn();
            InputChar();
            //Тест №3

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
        private void InputChar()
        {
            IWebElement el = null;
            driver.FindElement(By.Id("menuNavigation"))
                .FindElement(By.CssSelector("div.svzSimpleButton.gotoCoordsButton")).Click();
            try
            {
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("j");
               el = driver.FindElement(By.CssSelector("div.dijitTooltip > div.dijitTooltipContents"));
            }
            catch (Exception e)
            {
                Assert.Fail("Отсутствует напоминание о неправильном вводе параметров" + e.Message);
            }
            Assert.AreEqual(charError, el.Text, "Высветился неправильный текст об ошибке");

        }
        private void InputInt()
        {
            IWebElement el = null;
            driver.FindElement(By.Id("menuNavigation")).FindElement(By.CssSelector("div.svzSimpleButton.gotoCoordsButton")).Click();
            try
            {
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("100");

               el = driver.FindElement(By.CssSelector("div.dijitTooltip > div.dijitTooltipContents"));
            }
            catch (Exception e)
            {
                Assert.Fail("Отсутствует напоминание о неправильном вводе параметров" + e.Message);
            }
            Assert.AreEqual(intError, el.Text, "Высветился неправильный текст об ошибке");

        }
    }
}

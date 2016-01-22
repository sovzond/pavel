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
    /// Данный тест осуществляет проверку на изменение порядка отображения слоев.
    /// </summary>
    [TestClass]
    public class TestChangeSortLayers
    {
        //Тест не выполнен. Отсутствует проверка z-index'ирования.
        private IWebDriver driver;
        private string baseUrl;
        [TestInitialize]
        public void Setup()
        { 
            baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
            driver = new FirefoxDriver();
        }
        /// <summary>
        ///Данный метод перемещает последний слой на позицию первого.
        ///</summary>
        [TestMethod]
        public void CheckIndexLayer()
        {
            //Тест №16
            LogOn();
            IncrementLayer();

        }
        [TestCleanup]
        public void Clean()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Quit();
        }
        private void IncrementLayer()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_74")).Click();
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.Id("dojoUnique4")).FindElement(By.CssSelector("img")).Click();
        }
        private void LogOn()
        {
            
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }

    }
}

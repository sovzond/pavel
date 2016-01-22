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

        private IWebDriver driver;
        /// <summary>
        ///Данный метод перемещает последний слой на позицию первого.
        ///</summary>
        [TestMethod]
        public void CheckIndexLayer()
        {
            //Тест №16
            LogOn();
            IncrementLayer();
            //Выполнил Петров, Балов.
        }
        private void IncrementLayer()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_74")).Click();
            for (int i = 0; i < 3; i++)
                driver.FindElement(By.Id("dojoUnique4")).FindElement(By.CssSelector("img")).Click();
        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }

    }
}

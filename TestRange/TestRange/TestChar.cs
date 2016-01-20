using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace TestCoordinates
{
    /// <summary>
    /// Данный класс проводит тест на запись символа в поле градусов строки с.ш. в появившемся окне «Переход на координаты» и проверяет, будет ли отображено предупреждение.
    /// </summary>
    [TestClass]
    public class TestChar
    {
        private IWebDriver driver;
        /// <summary>
        /// Данный метод вносит символьное значение в ячейку с.ш. для проверки появдения сообщения.
        /// </summary>
        [TestMethod]
        public void InputCharValue()
        {
            //Тест №3
            LogOn();
            InputValue();
            //Тест выполнил Петров,Балов.
        }
        private void LogOn_test()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond/portal/login.aspx?ReturnUrl=%2fsovzond%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();

        }
        private void InputValue_test()
        {

            driver.FindElement(By.Id("sovzond_widget_SimpleButton_100")).Click();
            try
            {
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("h");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).Click();
            }
            catch (Exception)
            {
                Assert.AreEqual("Появление напоминающего окна", "dijit__MasterTooltip_0", "Напоминающее окно не отобразилось.");
            }

        }
        private void InputValue()
        {

            driver.FindElement(By.Id("sovzond_widget_SimpleButton_133")).Click();
            try
            {
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("h");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).Click();
            }
            catch (Exception)
            {
                Assert.AreEqual("Появление напоминающего окна", "dijit__MasterTooltip_0", "Напоминающее окно не отобразилось.");
            }

        }
    }
}

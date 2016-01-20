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
    ///  Данный класс тестирует базовые слои
    /// </summary>
    [TestClass]
    public class TestBaseLayers
  
    {

        private IWebDriver driver;
        private Actions actions;
        /// <summary>
        ///Данный методом открывает базовые слои и проверяет отображаются ли они на карте по одному.
        ///</summary>
        [TestMethod]
        public void CheckBaseLayers()
        {
            //Тест №4
            LogOn();
            CheckPlan();
            //Тест не выполнен до конца.
            //Не открываются базовые слои
        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }
        private void CheckPlan()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_71")).Click();
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_0")).Click();

            
            
        }

    }
}

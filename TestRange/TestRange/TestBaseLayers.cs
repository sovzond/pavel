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
        private string baseUrl;
        private IWebElement element;
        [TestInitialize]
        public void Setup()
        {
            baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
            driver = new FirefoxDriver();
        }
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
        }
        private void CheckPlan()
        {

            driver.FindElement(By.Name("slideMenu")).Click();
            //driver.FindElement(By.Id("sovzond_widget_SimpleButton_0")).Click();
           element = driver.FindElement(By.Id("sovzond_widget_SimpleButton_0"));
           var builder = new OpenQA.Selenium.Interactions.Actions(driver);
           builder.Click(element).Perform();

        
            
        }

    }
}

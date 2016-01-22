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
    /// Данный класс осуществляет тест на прозрачноть элементов слоя.
    /// </summary>
    [TestClass]
    public class TestTransparencyLayer
    {
        //Тест не выполнен. Отсутствует проверка прозрачности слоев на карте.
        private IWebDriver driver;
        private string baseUrl;
        [TestInitialize]
        public void Setup()
        {
            baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
            driver = new FirefoxDriver();
        }
        /// <summary>
        ///Данный метод приводить прозрачномть элемента к 0.
        ///</summary>
        [TestMethod]
        public void TestTransparency()
        {
            //Тест №15
            LogOn();
            ClickOnTransparency();

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
        private void ClickOnTransparency()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_74")).Click();           
            for (int i = 0; i < 55; i++)
            {
                driver.FindElement(By.ClassName("dijitSliderDecrementIconH")).Click();
                driver.FindElement(By.Id("dojoUnique2")).FindElement(By.ClassName("dijitSliderDecrementIconH")).Click();
                driver.FindElement(By.Id("dojoUnique3")).FindElement(By.ClassName("dijitSliderDecrementIconH")).Click();
                driver.FindElement(By.Id("dojoUnique4")).FindElement(By.ClassName("dijitSliderDecrementIconH")).Click();
            }
        
            
            

        }

    }
}

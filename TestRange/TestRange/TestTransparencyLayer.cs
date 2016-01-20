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

        private IWebDriver driver;
        /// <summary>
        ///Данный метод приводить прозрачномть элемента к 0.
        ///</summary>
        [TestMethod]
        public void TestTransparency()
        {
            //Тест №15
            LogOn();
            ClickOnTransparency();
            //Тест выполнил Петров,Балов
        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace TestCoordinates
{
    /// <summary>
    /// Данный тест проводит проверку на появление всплывающего окна при вводе неверных координат.
    /// </summary>
    [TestClass]
    public class TestInt
    {
        private IWebDriver driver;
        /// <summary>
        /// Данный метод реализует ввод неверных данные в ячейки для поиска координат.
        /// </summary>
        [TestMethod]
        public void TestTitle()
        {
            //Тест №2
            LogOn();
            InputValue();
            //Тест выполнил Петров,Балов.
        }

        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
            
        }
        private void InputValue()
        {

            driver.FindElement(By.Id("sovzond_widget_SimpleButton_100")).Click();
            try
            {
                driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("100");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys("100");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys("100");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys("100");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys("100");
                driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys("100");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).Click();
            }
            catch (Exception)
            {
                Assert.AreEqual("Появление напоминающего окна", "dijit__MasterTooltip_0", "Напоминающее окно не отобразилось.");
            }

        }
    }
    
}

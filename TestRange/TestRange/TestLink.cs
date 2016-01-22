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
    /// Данный класс проводит тест на отображение окна "Ссылка" и сравнивает отобразившийся экстент карты с текущим экстентом карты. 
    /// </summary>
    [TestClass]
    public class TestCurrentLink
    {
        private IWebDriver driver;
        /// <summary>
        ///Данный метод проверяет отображение окна "Ссылка" и осуществляет сравнение экстентов.
        ///</summary>
        [TestMethod]
        public void CheckLink() 
        {
            //Тест №14
            LogOn();
            MoveExtent();
            CheckBoxShadow();
            //Тест не выполнен до конца.
            //Не удалось выполнить проверку на отображение текущего экстента карты.
        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }
        private void  CheckBoxShadow()
        {
            try
            {
                driver.FindElement(By.Id("sovzond_widget_SimpleButton_93")).Click();
                driver.FindElement(By.Id("linkExtent")).Click();
            }
            catch(Exception)
            {
                Assert.AreEqual("Ожидание появления окна \"Ссылка\"", "linkExtent", "Окно \"Ссылка\" не отобразилось.");
            }

        }
        private void MoveExtent()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_100")).Click();
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("60");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys("53");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys("39");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys("69");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys("20");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys("27");
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_3")).Click();
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_99")).Click();
        }   
    }
}

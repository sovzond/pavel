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
    ///Данный класс проводит тест на  правильность нахождения точки по заданным координатам.
    /// </summary>
    [TestClass]
    public class TestMap
    {
        private IWebDriver driver;
        /// <summary>
        ///Данный метод заносит координаты и отображает их на карте путем указателя.
        ///</summary>
        [TestMethod]
        public void CheckXY()
        {
            //Тест №1
            LogOn();
            InputCoordWnd.get(driver).setLat(60, 50, 0).setLon(69, 59, 0).Click();
            //InputCoordinates();
            //Тест выполнил Петров,Балов.
        }
        private void InputCoordinates_test()
        {
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_100")).Click();
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("60");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys("50");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys("0");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys("69");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys("59");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys("0");
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_3")).Click();


        }
        private void LogOn_test()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }
        private void InputCoordinates()
        {

            driver.FindElement(By.Id("sovzond_widget_SimpleButton_133")).Click();
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("60");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys("50");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys("0");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys("69");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys("59");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys("0");
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_3")).Click();


        }
        private void LogOn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond/portal/login.aspx?ReturnUrl=%2fsovzond%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }


    }
}

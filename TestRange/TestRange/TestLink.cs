using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace TestRange
{

    [TestClass]
    public class TestCurrentLink
    {

        private IWebDriver driver;
        private string baseUrl;
        private string loginUrl = "http://91.143.44.249/sovzond_test/portal/";
        [TestInitialize]
        public void Setup()
        {
            baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
            driver = new FirefoxDriver();
        }
        /// <summary>
        ///Данный метод проверяет отображение окна "Ссылка" и осуществляет сравнение экстентов.
        ///</summary>
        [TestMethod]
        public void CheckLink()
        {
            LogOn();
            MoveExtent();
            //Тест 14
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
            driver.Navigate().GoToUrl("http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal");
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
            Assert.AreEqual(loginUrl, driver.Url, "Не удалось пройти авторизацию");
        }


    private void MoveExtent()
        {
           IWebElement element;
            string[] arrayTextBox = new string[6];
            driver.FindElement(By.Id("menuNavigation"))
                             .FindElement(By.CssSelector("div.svzSimpleButton.gotoCoordsButton")).Click(); //  XY        
            for(int i=0;i<arrayTextBox.GetLength(0);i++)
            {
                arrayTextBox[i] = "dijit_form_NumberTextBox_"+i;
            }
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_100")).Click();
            driver.FindElement(By.Id(arrayTextBox[0])).SendKeys("60");
            driver.FindElement(By.Id(arrayTextBox[1])).SendKeys("50");
            driver.FindElement(By.Id(arrayTextBox[2])).SendKeys("45");
            driver.FindElement(By.Id(arrayTextBox[3])).SendKeys("60");
            driver.FindElement(By.Id(arrayTextBox[4])).SendKeys("50");
            driver.FindElement(By.Id(arrayTextBox[5])).SendKeys("39");
            driver.FindElement(By.Id("gotoCoords"))
                            .FindElement(By.CssSelector("div.svzSimpleButton.button")).Click(); // найти
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("sovzond_widget_SimpleButton_99")).Click(); // закрыть
                                                                                 // driver.FindElement(By.ClassName("titleBox"))
                                                                                 //  .FindElement(By.CssSelector("div.svzSimpleButton.closeBtn")).Click();
            driver.FindElement(By.Id("menuDop"))
                            .FindElement(By.CssSelector("div.svzSimpleButton.linkBtn")).Click(); //ссылки открыть
            element = driver.FindElement(By.Id("linkExtent"))
                            .FindElement(By.CssSelector("textarea")); // считать информацию с текстого поля
            string fullLink = element.Text;
            int idxExtentCoords = fullLink.IndexOf('=');
            idxExtentCoords++;
            string onlyExtentCoords = fullLink.Substring(idxExtentCoords);
            string[] splitedExtentCoords = onlyExtentCoords.Split(',');
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string onlyExtentCoordsCurrent = (string)js.ExecuteScript("return window.portal.stdmap.map.getExtent().toString()");
            string[] splitedExtentCoordsCurrent = onlyExtentCoordsCurrent.Split(',');
            for(int i=0;i<4;i++)
                Assert.AreEqual(splitedExtentCoordsCurrent[i], splitedExtentCoords[i], "Текущий экстент карты не является корректным");
        }
    }
    public class InputCoordWnd
     {
         private IWebDriver driver;
 
        private InputCoordWnd(IWebDriver driver)
         {
             this.driver = driver;
         }
 
         static public InputCoordWnd get(IWebDriver driver)
         {
             driver.FindElement(By.ClassName("gotoCoordsButton")).Click();
             return new InputCoordWnd(driver);
         }
 
         public InputCoordWnd setLon(int degrees, int minutes, int seconds)
         {
             driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys(degrees.ToString());
             driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys(minutes.ToString());
             driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys(seconds.ToString());
             return this;
         }
 
         public InputCoordWnd setLat(int degrees, int minutes, int seconds)
         {
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys(degrees.ToString());
             driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys(minutes.ToString());
             driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys(seconds.ToString());
             return this;
         }
 
         public void Click()
         {
             driver.FindElement(By.CssSelector("#gotoCoords .button")).Click();
        }
    }
}

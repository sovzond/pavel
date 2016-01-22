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
        //Тест не выполнен. Отсутствует проверка отобразившегося экстента карты.
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
        ///Данный метод проверяет отображение окна "Ссылка" и осуществляет сравнение экстентов.
        ///</summary>
        [TestMethod]
        public void CheckLink() 
        {
            //Тест №14
            LogOn();
            MoveExtent();
            CheckBoxShadow();

        }
        [TestCleanup]
         private void Clean()
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
        private void  CheckBoxShadow()
        {
            try
            {
                
            }
            catch(Exception)
            {
                
            }

        }
        private void MoveExtent()
        {
            driver.FindElement(By.Id("menuNavigation"))
                 .FindElement(By.CssSelector("div.svzSimpleButton.gotoCoordsButton")).Click(); //  XY
            driver.FindElement(By.Id("dijit_form_NumberTextBox_0")).SendKeys("60");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_1")).SendKeys("53");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_2")).SendKeys("39");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_3")).SendKeys("69");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_4")).SendKeys("20");
            driver.FindElement(By.Id("dijit_form_NumberTextBox_5")).SendKeys("27");          
            driver.FindElement(By.Id("gotoCoords"))
                .FindElement(By.CssSelector("div.svzSimpleButton.button")).Click(); // найти
            System.Threading.Thread.Sleep(1000);
               driver.FindElement(By.Id("sovzond_widget_SimpleButton_99")).Click(); // закрыть
           // driver.FindElement(By.ClassName("titleBox"))
                 //  .FindElement(By.CssSelector("div.svzSimpleButton.closeBtn")).Click();
            driver.FindElement(By.Id("menuDop"))
                .FindElement(By.CssSelector("div.svzSimpleButton.linkBtn")).Click(); //ссылки открыть
            element = driver.FindElement(By.Id("linkExtent"))
                .FindElement(By.CssSelector("textarea"));
            string fullLink = element.Text;
            int idx = fullLink.IndexOf('=');
            idx++; 
            string firstValue = fullLink.Substring(idx, 15);
            idx += 16;
            string secondValue = fullLink.Substring(idx, 15);
            idx += 16;
            string thirdValue = fullLink.Substring(idx, 15);
            idx += 16;
            string fourthValue = fullLink.Substring(idx, 13);
      
        }   
    }
}

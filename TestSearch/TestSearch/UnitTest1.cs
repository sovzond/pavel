using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace TestSearch
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private const string baseUrl = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal";
        [TestMethod]
        public void TestSearch()
        {
            Search("амбар");
            
           
        }
        [TestMethod]
        public void TestError()
        {
           Search("проверка");
        }
        [TestMethod]
        public void TestRegister()
        {
            testRegister("фАкЕл");
            
        }
        private void Search(string attributeSearch)
        {
            
            string[] arraySearch = new string[4];
            arraySearch[0] = "факел";
            arraySearch[1] = "амбар";
            arraySearch[2] = "кустовая площадка";
            arraySearch[3] = "дожимная насосная станция";
            string localAttributeSearch = attributeSearch.ToLower();
            LogIn();
            driver.FindElement(By.ClassName("searchPanel")).Click();
            driver.FindElement(By.ClassName("searchPanel")).SendKeys(localAttributeSearch);
            driver.FindElement(By.Id("textSearch2")).Click();
            for(int i=0;i<arraySearch.GetLength(0);i++)
            {
                if (!(localAttributeSearch==arraySearch[0] ||
                    localAttributeSearch == arraySearch[1] ||
                    localAttributeSearch == arraySearch[2] ||
                    localAttributeSearch == arraySearch[3]))
                {
                    Assert.Fail("Результат поиска: ничего не найдено");
                }
            }
          

        } 
        private void LogIn()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.Id("txtUser")).SendKeys("guest");
            driver.FindElement(By.Id("txtPsw")).SendKeys("guest");
            driver.FindElement(By.Id("cmdLogin")).Click();
        }
        private void testRegister(string attributeSearch)
        {
            LogIn();
            driver.FindElement(By.ClassName("searchPanel")).Click();
            driver.FindElement(By.ClassName("searchPanel")).SendKeys(attributeSearch);
            driver.FindElement(By.Id("textSearch2")).Click();


        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Drawing;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        const string url = "http://91.143.44.249/sovzond_test/portal/login.aspx?ReturnUrl=%2fsovzond_test%2fportal%2f";
 
               
        [TestMethod]
        public void LoginError()
        {
            Login("gues", "guest");   
        }

        [TestMethod]
        public void LoginSucces()
        {
            Login("guest", "guest");
        }

        private void Login(string login,string password)
        {
           // string dt = DateTime.Now.Date.ToShortDateString().ToString();
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("txtUser")).SendKeys(login);
            driver.FindElement(By.Id("txtPsw")).SendKeys(password);
            driver.FindElement(By.Id("cmdLogin")).Click();
            if (driver.Url != "http://91.143.44.249/sovzond_test/portal/")
            {
                
                Screenshot src = ((ITakesScreenshot)driver).GetScreenshot();
                src.SaveAsFile(@"C:\Users\student\Desktop\" + DateTime.Now.ToString() + ".png", ImageFormat.Png);
                Assert.AreEqual("error", "lbLoginError", "Неверный логин или пароль");
                

            }
              
        }
        private void CreateDerectory(string addres)
        {

        }

    }
}

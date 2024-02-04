using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson34_LocalDBStorage
    {
        IWebDriver driver;
        //IWebElement elem;
        IJavaScriptExecutor js;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://bestvpn.org/html5demos/storage/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            js = (IJavaScriptExecutor)driver;
        }

        [Test]  
        public void Test01_VerifySessionStorage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(250));
            driver.FindElement(By.Id("session")).SendKeys("Vasya");
            //string actualItem = (string)js.ExecuteScript("return window.sessionStorage.getItem('value');");
            //Console.WriteLine("Session storage item: " + actualItem);
            Console.WriteLine("session");
        }

        //[TearDown]

        //public void AfterMethod()
        //{
        //    driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        //    Thread.Sleep(5000);
        //}

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

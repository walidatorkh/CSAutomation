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
            //Thread.Sleep(TimeSpan.FromSeconds(25));
            string expected = "Vasya";
            driver.FindElement(By.Id("session")).SendKeys("Vasya");
            string actualItem = (string)js.ExecuteScript("return window.sessionStorage.getItem('value');");
            Console.WriteLine("Session storage item: " + actualItem);
            Console.WriteLine("session");
            Assert.AreEqual(expected, actualItem);
        }

        [Test]
        public void Test02_VerifyLocalStorage()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(25));
            string expected = "Petrov";
            driver.FindElement(By.Id("local")).SendKeys("Petrov");
            string actualItem = (string)js.ExecuteScript("return window.localStorage.getItem('value');");
            Console.WriteLine("Local storage item: " + actualItem);
            Assert.AreEqual(expected, actualItem);
        }

        [Test]
        public void Test03_ClearAndVerifySessionStorage()
        {
            js.ExecuteScript("return window.sessionStorage.clear();");
            string actualSessionItem = (string)js.ExecuteScript("return window.sessionStorage.getItem('value');");
            Assert.AreEqual(null, actualSessionItem);
        }

        [Test]
        public void Test04_ClearAndVerifyLocalStorage()
        {
            js.ExecuteScript("return window.localStorage.clear();");
            string actualLocalItem = (string)js.ExecuteScript("return window.localStorage.getItem('value');");
            Assert.AreEqual(null, actualLocalItem);
        }


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

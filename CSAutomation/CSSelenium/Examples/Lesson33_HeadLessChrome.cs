using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CSSelenium.Examples
{

    [TestFixture]
    class Lesson33_HeadLessChrome
    {
        IWebDriver driver;
        //IWebElement elem;
        ChromeOptions chromeOptions;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/bmi/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Test01_VerifyBMI()
        {
            string expected = "36";
            driver.FindElement(By.Id("weight")).Clear();
            driver.FindElement(By.Id("weight")).SendKeys("110");
            driver.FindElement(By.Id("hight")).Clear();
            driver.FindElement(By.Id("hight")).SendKeys("176");
            driver.FindElement(By.Id("calculate_data")).Click();
            String ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
            Console.WriteLine("My result: " + ActualResult);
            Assert.AreEqual(expected, ActualResult, "Your BMI results has failed");

        }

        [TearDown]

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

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson19_bmi
    {
        IWebDriver driver;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/bmi/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

        }

        [Test]
        public void Test01_VerifyURL()
        {
            string expected = "37";
            driver.FindElement(By.Id("weight")).SendKeys("120");
            driver.FindElement(By.Id("hight")).SendKeys("180");
            driver.FindElement(By.Id("calculate_data")).Click();
            string actual = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
            Assert.AreEqual(expected, actual, "Your BMI results test has failed!");
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

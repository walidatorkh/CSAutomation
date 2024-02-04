using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace CSSelenium.Examples
{
    [TestFixture]
    class Lesson12_LocatorsBasic
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartSesion()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Position = new Point(0, 0);
            //driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Navigate().GoToUrl("https://www.mortgagecalculator.org/");
        }

        [Test]
        public void Test01_LocatingElements()
        {
            IWebElement HomeValue = driver.FindElement(By.Id("homeval"));
            Console.WriteLine(HomeValue);
        }

        [Test]
        public void Test02_LocatingElements()
        {
            IWebElement InterestRate = driver.FindElement(By.Name("param[interest_rate]"));
            Console.WriteLine(InterestRate);
        }

        [Test]
        public void Test03_LocatingElements()
        {
            IList<IWebElement> butons = driver.FindElements(By.ClassName("styled-button"));
            Console.WriteLine(butons[6]);
        }

        [Test]
        public void Test04_LocatingElements()
        {
            IWebElement MortgagaCalcLink = driver.FindElement(By.LinkText("Mortgage Calcs"));
            Console.WriteLine(MortgagaCalcLink);
        }

        [Test]
        public void Test05_LocatingElements()
        {
            IWebElement MortgagaCalcPartialLink = driver.FindElement(By.PartialLinkText("Mortgage Cal"));
            Console.WriteLine(MortgagaCalcPartialLink);
        }

        [OneTimeTearDown]
        public void CloseSesion()
        {
            driver.Quit();
        }
    }
}

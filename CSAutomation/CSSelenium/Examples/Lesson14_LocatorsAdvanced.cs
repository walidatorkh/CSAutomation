using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace CSSelenium.Examples
{
    [TestFixture]
    class Lesson14_LocatorsAdvanced
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
        public void Test01_LocatingXPathElements()
        {
            IWebElement HomeValue = driver.FindElement(By.XPath("//label[@for='homeval']"));
            Console.WriteLine(HomeValue);
        }

        [Test]
        public void Test02_LocatingXPathElements()
        {
            IWebElement InterestRate = driver.FindElement(By.XPath("//label[@for='intrstsrate']"));
            Console.WriteLine(InterestRate);
        }

        [Test]
        public void Test03_LocatingXPathElements()
        {
            IWebElement butons = driver.FindElement(By.XPath("//a[@class='example8 cboxElement']//input[@name='ratebutton']"));
            Console.WriteLine(butons);
        }

        [Test]
        public void Test04_LocatingCSSElements()
        {
            IWebElement MortgagaCalcLink = driver.FindElement(By.CssSelector("body > section > section > div > div > nav > ul > li:nth-child(1) > a"));
            Console.WriteLine(MortgagaCalcLink);
        }

        [Test]
        public void Test05_LocatingCSSElements()
        {
            IWebElement YourMortgagePaymentInformation = driver.FindElement(By.CssSelector("div[class='black-block'] strong"));
            Console.WriteLine(YourMortgagePaymentInformation);
        }

        [OneTimeTearDown]
        public void CloseSesion()
        {
            driver.Quit();
        }
    }
}

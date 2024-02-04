using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Threading;

namespace CSSelenium.Exercises
{
    [TestFixture]
    class Exercise_Synchronization
    {
        IWebDriver driver;
        bool disp;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/ex_synchronization.html");
        }

        [Test]
        public void Test01ShowRendered()
        {
            driver.FindElement(By.Id("rendered")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.Id("finish2"), "My Rendered Element After Fact!"));
            Assert.True(driver.FindElement(By.Id("finish2")).Displayed);
        }

        [Test]
        public void Test02ShowHidden()
        {
            driver.FindElement(By.Id("hidden")).Click();
            Thread.Sleep(10000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            Assert.True(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.XPath("//*[@id='contact_info_left']/text()[2]"), "Element on page that is hidden")));
            Console.WriteLine("Element on page that is hidden");

        }

        [Test]
        public void Test03ShowRemovedCheckBox()
        {
            disp = driver.FindElement(By.Id("checkbox")).Displayed;
            Console.WriteLine("checkbox Displayed: " + disp);
            driver.FindElement(By.XPath("//*[@id='btn']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            disp = driver.FindElement(By.Id("message")).Displayed;
            Console.WriteLine("It's gone! " + disp);           
        }


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

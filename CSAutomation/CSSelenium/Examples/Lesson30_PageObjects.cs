using System;
using System.Threading;
using CSSelenium.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;


namespace CSSelenium.Examples
{
    [TestFixture]
    class Lesson30_PageObjects
    {
        IWebDriver driver;
        LoginPage login;
        HomePage home;  

        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            login = new LoginPage(driver);
            home = new HomePage(driver);
        }

        [Test]

        public void Test01_VerifyCartItem()
        {
            try
            {
                login.LoginAction("standard_user", "secret_sauce");
                home.AddToCart(0);
                home.VerifyItemsInCart(1);
                home.RemoveFromCart(0);
                home.VerifyItemsInCart(0);
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed, See detailes in next message: " + e.Message);
            }
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }

    }
}

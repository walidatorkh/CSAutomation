using System;
using System.Threading;
using CSSelenium.PageObjects;
using CSSelenium.PageObjectsExercise;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;

namespace CSSelenium.Exercises
{
    [TestFixture]
    class Exercise_PageObjects
    {
        IWebDriver driver;
        //LoginPage login = new LoginPage();
        LoginToPage loginToPage;
        FormPage formPage;
        AfterLoginPage afterLoginPage;

        [OneTimeSetUp]
        public void StartSession()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/webdriveradvance.html");
            // PageFactory.InitElements(driver, login);
            loginToPage = new LoginToPage(driver);
            formPage = new FormPage(driver);
            afterLoginPage = new AfterLoginPage(driver);

        }

        [Test]

        public void Test01_VerifyLoginSuccess()
        {
            try
            {
                Thread.Sleep(5000);
                loginToPage.LoginAction("selenium", "webdriver");
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed, See detailes in next message: " + e.Message);
            }
        }

        [Test]

        public void Test02_VerifyFormPageSuccess()
        {
            try
            {
                loginToPage.LoginAction("selenium", "webdriver");
                Thread.Sleep(2000);
                formPage.AddFormAction("Zopa", "121", "Hell");
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed, See detailes in next message: " + e.Message);
            }
        }

        [Test]

        public void Test03_VerifyAfterLoginPage()
        {
            try
            {
                loginToPage.LoginAction("selenium", "webdriver");
                Thread.Sleep(2000);
                formPage.AddFormAction("Zopa", "121", "Hell");
                afterLoginPage.AfterLoginAction();
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

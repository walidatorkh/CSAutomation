using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using CSSelenium.PageObjects;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;
using System.Drawing;


namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson31_DDT
    {
        IWebDriver driver;
        LoginPage login;
        Actions action;
        public ExtentReports extent;
        public ExtentTest test;
        DateTime datetime;

        public Point Locator { get; private set; }

        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            login = new LoginPage(driver);
            extent = new ExtentReports(@"C:\automation\Reports\testReportLesson31_DDT.html");
            action = new Actions(driver);
        }


        [TestCase("standard_user", "secret_sauce", true)]
        [TestCase("kuku", "secret_sauce", false)]
        [TestCase("standard_user", "kuku", false)]

        public void Test01_LoginDDT(string user, string pass, bool shouldLogin)
        {
            //driver.FindElement(By.Id("user-name")).Clear();
            //driver.FindElement(By.Id("user-name")).SendKeys(user);

            //driver.FindElement(By.Id("password")).Clear();
            //driver.FindElement(By.Id("password")).SendKeys(pass);
            //Thread.Sleep(5000);
            //driver.FindElement(By.Id("login-button")).Click();

            DateTime currentDateTimeUTC = DateTime.UtcNow;
            test = extent.StartTest("Login Data Driven Test", "Testing Result for Login DDT");
            try
            {
                test.Log(LogStatus.Pass, "Before login using user: " + user + " pass: "+ pass);
                login.LoginAction(user, pass);
                test.Log(LogStatus.Pass, "After login using user: " + user + " pass: " + pass);

                if (shouldLogin)
                {
                    Thread.Sleep(5000);
                    test.Log(LogStatus.Pass, "After login using user: " + user + " pass: " + pass + " when shouldLogin equal to " + shouldLogin);
                    Assert.True(driver.FindElement(By.CssSelector("#header_container > div.header_secondary_container > span")).Displayed);
                    Thread.Sleep(5000);
                }

                else
                {
                    test.Log(LogStatus.Pass, "After login using user: " + user + "pass: " + pass + " when shouldLogin equal to " + shouldLogin);
                    Assert.True(driver.FindElement(By.XPath("//*[@id='login_button_container']/div/form/div[3]/h3[@data-test='error']")).Displayed);
                    Thread.Sleep(5000);
                }
            }
            catch (Exception e)
            {

                test.Log(LogStatus.Fail, "Test failed, see detailes: " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Test failed, Time of failure: " + currentDateTimeUTC + " see detailes in next message: " + e.Message);
            }

        }

        [TearDown]

        public void AfterMethod()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(5000);
            extent.EndTest(test);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            extent.Flush();
            extent.Close();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }

        public string ScreenShot()
        {
            DateTime datetime = DateTime.UtcNow;
            string tm = datetime.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_");
            string location = @"C:\automation\Reports\screen_" + tm + ".png";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(location, ScreenshotImageFormat.Png);
            return location;
        }

    }
}

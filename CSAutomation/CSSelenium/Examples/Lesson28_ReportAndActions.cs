using System;
using System.Drawing;
using System.Threading;
using System.Timers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;


namespace CSSelenium.Examples
{
    [TestFixture]
    class Lesson28_ReportAndActions
    {

        IWebDriver driver;
        Actions action;
        public ExtentReports extent;
        public ExtentTest test;
        DateTime datetime;

        public Point Locator { get; private set; }

        [OneTimeSetUp]
        public void LoadDriver()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://marcojakob.github.io/dart-dnd/basic/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Console.WriteLine("SetUp Finished Successfully");
            extent = new ExtentReports(@"C:\automation\Reports\testReportLesson28_ReportAndAction.html");
            action = new Actions(driver);
            // Add system information
            //test.AssignCategory("YourTestCategory");
            //test.AssignCategory("OS", Environment.OSVersion.ToString());
            //test.AssignCategory("Browser", "Chrome");

        }

        [Test]
        public void Test01_VerifyBin()

        {
            DateTime currentDateTimeUTC = DateTime.UtcNow;
            test = extent.StartTest("Drag & Drop", "Testing Result for Drag & Drop");
            try
            {                
                IWebElement source = driver.FindElement(By.ClassName("document"));
                test.Log(LogStatus.Pass, "source element located successfully");
                IWebElement target = driver.FindElement(By.ClassName("trash"));
                test.Log(LogStatus.Pass, "Target element located successfully");
                action.DragAndDrop(source, target).Build().Perform();
                test.Log(LogStatus.Pass, "Drag And Drop ended successfully");
                //Assert.True(driver.FindElement(By.ClassName("full")).Displayed);
                Assert.True(driver.FindElement(By.CssSelector("div[class='trash full']")).Displayed);
                test.Log(LogStatus.Pass, "Test passed");
            }
            catch (Exception e)
            {
                test.Log(LogStatus.Fail, "Test failed, see detailes: " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Test failed, Time of failure: " + currentDateTimeUTC + " see detailes in next message: " + e.Message);
            }
        }



        [TearDown]
        public void afterMethod()
        {
            extent.EndTest(test);
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            extent.Flush();
            extent.Close();
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

        //public int RandomNumber()
        //{
        //    Random random = new Random();
        //    return random.Next(1, 999999999);
        //}

    }

}

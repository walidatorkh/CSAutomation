using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;


namespace CSSelenium.Exercises
{
    [TestFixture]
    class Lesson_ReportAndActions
    {

        IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        string ActualResult;
        string ExpectedResult;
        public Point Locator { get; private set; }

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/bmi/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("SetUp Finished Successfully");
            extent = new ExtentReports(@"C:\automation\Reports\testReport1.html");

        }

        [Test]
        public void Test01BmiOverweight()

        {
            test = extent.StartTest("BMI Overweight", "Testing results for BMI");
            string ExpectedResult = "36";
            try
            {
                
                driver.FindElement(By.Id("weight")).Clear();
                test.Log(LogStatus.Info, "table weight empty");
                driver.FindElement(By.Id("weight")).SendKeys("110");
                test.Log(LogStatus.Info, "weight are added");
                driver.FindElement(By.Id("hight")).Clear();
                test.Log(LogStatus.Info, "table hight empty");
                driver.FindElement(By.Id("hight")).SendKeys("176");
                test.Log(LogStatus.Info, "hight are added");
                driver.FindElement(By.Id("calculate_data")).Click();
                test.Log(LogStatus.Info, "button Calculate are clicked");
                String ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
                Assert.AreEqual(ExpectedResult, ActualResult);
                test.Log(LogStatus.Pass, "Actual Result [" + ActualResult + "] matches Expected result [" + ExpectedResult + "] ");
            }
            catch (Exception ex)    
            {
                test.Log(LogStatus.Fail, "Terst Failed " + ex + test.AddScreenCapture(ScreenShot()));
                Assert.AreEqual(ExpectedResult, ActualResult, "Your BMI results has failed");
            }


        }


        [Test]
        public void Test02BmiThin()

        {
            test = extent.StartTest("That you are too thin", "Testing results for BMI");
            string ExpectedResult = "36";
            try
            {

                driver.FindElement(By.Id("weight")).Clear();
                test.Log(LogStatus.Info, "table weight empty");
                driver.FindElement(By.Id("weight")).SendKeys("50");
                test.Log(LogStatus.Info, "weight are added");
                driver.FindElement(By.Id("hight")).Clear();
                test.Log(LogStatus.Info, "table hight empty");
                driver.FindElement(By.Id("hight")).SendKeys("200");
                test.Log(LogStatus.Info, "hight are added");
                driver.FindElement(By.Id("calculate_data")).Click();
                test.Log(LogStatus.Info, "button Calculate are clicked");
                String ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
                Assert.AreEqual(ExpectedResult, ActualResult);
                test.Log(LogStatus.Pass, "Actual Result [" + ActualResult + "] matches Expected result [" + ExpectedResult + "] ");
            }
            catch (Exception e)
            {
                test.Log(LogStatus.Fail, "Test Failed " + e + test.AddScreenCapture(ScreenShot()));
                Assert.AreEqual(ExpectedResult, ActualResult, "Your BMI results has failed");
            }


        }

        [Test]
        public void Test03BmiHealthy()

        {
            test = extent.StartTest("BMI Healthy", "Testing results for BMI");
            string ExpectedResult = "25";
            try
            {

                driver.FindElement(By.Id("weight")).Clear();
                test.Log(LogStatus.Info, "table weight empty");
                driver.FindElement(By.Id("weight")).SendKeys("110");
                test.Log(LogStatus.Info, "weight are added");
                driver.FindElement(By.Id("hight")).Clear();
                test.Log(LogStatus.Info, "table hight empty");
                driver.FindElement(By.Id("hight")).SendKeys("176");
                test.Log(LogStatus.Info, "hight are added");
                driver.FindElement(By.Id("calculate_data")).Click();
                test.Log(LogStatus.Info, "button Calculate are clicked");
                String ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
                Assert.AreEqual(ExpectedResult, ActualResult);
                test.Log(LogStatus.Pass, "Actual Result [" + ActualResult + "] matches Expected result [" + ExpectedResult + "] ");
            }
            catch (Exception ex)
            {
                test.Log(LogStatus.Fail, "Terst Failed " + ex + test.AddScreenCapture(ScreenShot()));
                Assert.AreEqual(ExpectedResult, ActualResult, "Your BMI results has failed");
            }


        }




        [TearDown]
        public void tearDown()
        {
            driver.FindElement(By.Id("reset_data")).Click();
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

        public String ScreenShot() 
        {
            string location = @"C:\automation\Reports\screen_" + RandomNumber() + ".png";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(location, ScreenshotImageFormat.Png);
            return location;
        }

        public int RandomNumber()
        {
            Random random = new Random();   
            return random.Next(1, 999999999);
        }
    }
}

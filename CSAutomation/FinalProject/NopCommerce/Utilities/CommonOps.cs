using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using System.Xml;

namespace FinalProject.NopCommerce.Utilities
{
    class CommonOps : Base
    {
        public static string GetData(string nodeName)
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Automation\CSAutomation\CSAutomation\FinalProject\NopCommerce\Configuration\data.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(nodeName))
                            return reader.ReadString();
                    }
                }
            }
            return "NULL";
        }

        public void InitBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    {
                        driver = new ChromeDriver();
                        break;
                    }
                case "firefox":
                    {
                        driver = new FirefoxDriver();
                            break;
                    }
                default:
                    {
                        throw new ArgumentException("Browser not supported");
                    }
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GetData("URL"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")));
        }

        [OneTimeSetUp]
        public void LoadDriver()
        {
            InitBrowser(GetData("BROWSER_TYPE"));
            ManagePages.InitElements();
            InitReport();
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            extent.Flush();
            extent.Close();
            driver.Quit();
        }

        public static void InitReport()
        {
            Directory.CreateDirectory(GetData("REPORT_FILE_PATH") + timeStamp);
            extent = new ExtentReports(GetData("REPORT_FILE_PATH") + timeStamp + GetData("REPORT_FILE_NAME"));
        }

        [SetUp]
        public void BeforeMethod()
        {
            string testName = TestContext.CurrentContext.Test.Name.Split('_')[0];
            string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
            test = extent.StartTest(testName, testDescription);
        }

        [TearDown]
        public void AfterMethod()
        {
            extent.EndTest(test);
        }

        public static string ScreenShot()
        {
            DateTime dateTime = DateTime.Now;
            string timeStamp = dateTime.ToString("yyyy_MM_dd_HH_mm_ss");
            var fileName = string.Format("screen_{0}.png", timeStamp);
            string location = Path.Combine(GetData("REPORT_FILE_PATH"), fileName);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(location, ScreenshotImageFormat.Png);
            return location;
        }
    }
}

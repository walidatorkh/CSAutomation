using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Xml;

namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Exercise_ExternalFiles
    { 
        IWebDriver driver;
        WebDriverWait wait;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GetData("URL"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Test01zopa()
        {
            try 
            { 
                Thread.Sleep(1000);
                driver.FindElement(By.Name("username")).SendKeys(GetData("USER"));
                driver.FindElement(By.Name("password")).SendKeys(GetData("PASSWORD"));
                Thread.Sleep(1000);
                driver.FindElement(By.Id("submit")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("loggedin"));
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, deatils in: " + e.Message);
                Assert.Fail("Assert.Fail>>>LOGIN failed, deatils in: " + e.Message);
            }
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }

        public string GetData(string nodeName)
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Automation\CSAutomation\CSAutomation\CSSelenium\externalData\dataActions.xml"))
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
    }
}

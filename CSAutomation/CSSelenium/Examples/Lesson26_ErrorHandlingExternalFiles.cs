using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Xml;

namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson26_ErrorHandlingExternalFiles
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Test01()
        {
            try 
            { 
                driver.FindElement(By.LinkText("Books")).Click();
                SelectElement currency = new SelectElement(driver.FindElement(By.Id("customerCurrency")));
                currency.SelectByText(GetData("CURRENCY"));
                string actualPrice = driver.FindElement(By.CssSelector("span[class='price actual-price']")).Text;
                Assert.AreEqual(GetData("EXPECTED"), actualPrice);
                Console.WriteLine("Test passed >> Actual price is: " + actualPrice + " = EXPECTED price");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, deatils in: " + e.Message);
                Assert.Fail("Assert.Fail>>>Test failed, deatils in: " + e.Message);
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
            using (XmlReader reader = XmlReader.Create(@"C:\Automation\Configuration\data.xml"))
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

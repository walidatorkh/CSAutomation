using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace CSSelenium.Examples
{
    [TestFixture]

    public class Lesson08_OpenBrowsers
    {
        [OneTimeSetUp]
        public void Init()
        { Console.WriteLine("OneTimeSetUp"); }

        [SetUp]
        public void Init1()
        { Console.WriteLine("SetUp"); }

        [Test]
        public void Test01OpenChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Quit();
        }

        [Test]
        public void Test02OpenFireFox()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Quit();
        }

        [Test]
        public void Test03OpenIE()
        {
            IWebDriver driver = new OpenQA.Selenium.IE.InternetExplorerDriver();
            driver.Quit();
        }

        [TearDown]
        public void Cleanup1()
        { Console.WriteLine("TearDown"); }

        [OneTimeTearDown]
        public void Cleanup()
        { Console.WriteLine("OneTimeTearDown"); }
    }
}

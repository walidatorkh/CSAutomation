using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CSSelenium.Examples
{

    [TestFixture]
    class Lesson32_EmulatingMobileDevice
    {
        IWebDriver driver;
        //IWebElement elem;
        ChromeOptions chromeOptions;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            //chromeOptions = new ChromeOptions();
            //chromeOptions.EnableMobileEmulation("iPad");
            //driver = new ChromeDriver(chromeOptions);
            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("https://atidcollege.co.il/digital/");
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        [TestCase("iPhone 12 Pro")]
        [TestCase("iPad")]
        [TestCase("Pixel 2")]


        [Test]
        public void EmulateMobileDevice(string deviceName)
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.EnableMobileEmulation(deviceName);
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/digital/");
            Console.WriteLine($"Running test with mobile emulation: {deviceName}");
            Thread.Sleep(3000);
            Assert.True(driver.FindElement(By.CssSelector("body > center:nth-child(3) > a")).Displayed);

        }

        [TearDown]


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

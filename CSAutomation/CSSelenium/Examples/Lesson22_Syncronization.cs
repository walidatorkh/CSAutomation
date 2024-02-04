using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson22_Syncronization
    {
        IWebDriver driver;
        WebDriverWait wait;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(@"C:\automation\example\my-old-page.html");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

        }

        [Test]
        public void Test01()
        {
            //Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("new_title")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("new_title")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("New Page"));

            IWebElement title = driver.FindElement(By.Id("new_title"));

        }

        [Test]
        public void Test02PrintExpanciveItem()
        {
            //Thread.Sleep(2000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("new_title")));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("new_title")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("New Page"));

            IWebElement title = driver.FindElement(By.Id("new_title"));

        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

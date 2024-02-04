using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSelenium.Examples
{
    [TestFixture]
    class Lesson11_XPath
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartSesion()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Position = new Point(0, 0);
            //driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Navigate().GoToUrl("https://amazon.com");
        }

        [Test]
        public void Test01_Xpath_span1()
        {
            driver.FindElement(By.XPath("//span[@class='nav-cart-icon nav-sprite']")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [Test]
        public void Test02_Xpath_id()
        {
            driver.FindElement(By.XPath("//*[@id='nav-cart-count-container']/span[2]")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [Test]
        public void Test03_Xpath_full()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [Test]
        public void Test04_CSS_span()
        {
            driver.FindElement(By.CssSelector(".nav-cart-icon.nav-sprite")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [Test]
        public void Test05_CSS_span()
        {
            driver.FindElement(By.CssSelector("span[class='nav-cart-icon nav-sprite']")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [Test]
        public void Test06_CSS_span()
        {
            driver.FindElement(By.CssSelector("#nav-cart-count-container > span.nav-cart-icon.nav-sprite")); ////*[@id="nav-cart-count-container"]/span[2]
            Console.WriteLine("Yes");///html/body/div[1]/header/div/div[1]/div[3]/div/a[4]/div[1]/span[2]
        }

        [OneTimeTearDown]
        public void CloseSesion()
        {
            driver.Quit();
        }
    }
}

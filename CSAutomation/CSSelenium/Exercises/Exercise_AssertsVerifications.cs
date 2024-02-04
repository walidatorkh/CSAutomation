using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSelenium.Exercises
{
    [TestFixture]
    class Exercise_AssertsVerifications
    {

        IWebDriver driver;

        public Point Locator { get; private set; }

        IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/bmi/");
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        [Test]
        public void Test01()
        {
            string expected = "36";
            driver.FindElement(By.Id("weight")).Clear();
            driver.FindElement(By.Id("weight")).SendKeys("110");
            driver.FindElement(By.Id("hight")).Clear();
            driver.FindElement(By.Id("hight")).SendKeys("176");
            driver.FindElement(By.Id("calculate_data")).Click();
            String ActualResult = driver.FindElement(By.Id("bmi_result")).GetAttribute("value");
            Assert.AreEqual(expected, ActualResult, "Your BMI results has failed");

        }

        [Test]
        public void Test02()
        {
            //driver.FindElement(By.Id("weight")).Clear();
            //driver.FindElement(By.Id("weight")).SendKeys("110");
            //driver.FindElement(By.Id("hight")).Clear();
            //driver.FindElement(By.Id("hight")).SendKeys("176");
            Console.WriteLine("1");
            Locator = driver.FindElement(By.Id("calculate_data")).Location;
            Console.WriteLine("2");
            Console.WriteLine(Locator);
            Console.WriteLine("3");
            Console.WriteLine(driver.FindElement(By.Id("calculate_data")).Displayed);
            Console.WriteLine("4");
            Assert.IsTrue(driver.FindElement(By.Id("calculate_data")).Displayed);
            Console.WriteLine("5");
            Console.WriteLine(driver.FindElement(By.Id("calculate_data")).Enabled);
            Console.WriteLine("6");
            Assert.True(driver.FindElement(By.Id("calculate_data")).Enabled);
            Console.WriteLine("7");

        }

        [Test]
        public void Test03()
        {
            Locator = driver.FindElement(By.Id("calculate_data")).Location;
            Console.WriteLine(Locator);
            Console.WriteLine(driver.FindElement(By.Id("calculate_data")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("calculate_data")).Displayed);
            Console.WriteLine(driver.FindElement(By.Id("calculate_data")).Enabled);
            Assert.True(driver.FindElement(By.Id("calculate_data")).Enabled);
        }


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

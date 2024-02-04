using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.Threading;

namespace CSSelenium.Exercises
{
    [TestFixture]
    class ErrorHandling
    {
        IWebDriver driver;
        bool disp;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/ex_synchronization.html");
        }

        [Test]
        public void Test01VrifyIfExist()
        {
            try 
            { 
                driver.FindElement(By.Id("btn")).Click();
                Thread.Sleep(5000);
                disp = driver.FindElement(By.Id("checkbox")).Displayed;
                Console.WriteLine("checkbox Displayed: " + disp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("WebDriver could not find the element but nevertheless test did not fail" + ex);
            }
            
        }

        [Test]
        public void Test02VrifyIfExist()
        {
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            try
            {
                disp = driver.FindElement(By.Id("checkbox")).Displayed;
                Console.WriteLine("checkbox Displayed: " + disp);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Element was not found :" + ex);
            }
            //finally
            //{
            //    Console.WriteLine("Finish a test!");
            //}

        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

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
    internal class Lesson16_Controllers2
    {
        IWebDriver driver;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            //Login to site
            driver.FindElement(By.Id("user-name")).Clear();
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

        }

        [Test]
        public void Test01PrintExpanciveItem()
        {
            //Select from dropdown
            SelectElement Sorting = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));
            Sorting.SelectByValue("hilo");
            //get and print highest price
            IList<IWebElement> prices = driver.FindElements(By.ClassName("inventory_item_price"));
            Console.WriteLine("The most expansive item is: " + prices[0]);

            //logout
            driver.FindElement(By.ClassName("bm-burger-button")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Logout")).Click();
            //driver.FindElement(By.Id("logout_sidebar_link")).Click();

        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

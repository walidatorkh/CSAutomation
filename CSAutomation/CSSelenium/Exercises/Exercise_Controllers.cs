using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSelenium.Exercises
{

    [TestFixture]
    internal class Exercise_Controllers
    {
        IWebDriver driver;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/ex_controllers.html");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void Test01()
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Igor");
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Khaykin");
            //driver.FindElement(By.Name(" Male ")).Click();
            //Console.WriteLine(driver.FindElement(By.Name(" Male ")));
            ///html/body/div[2]/div/div/div/div/form/fieldset/table/tbody/tr/td[1]/div[2]/p[2]/text()
            ///////*[@id="sex-0"]
            SelectElement MyContinents = new SelectElement(driver.FindElement(By.Id("continents")));
            MyContinents.SelectByText("Australia");
            IList<IWebElement> Continents = MyContinents.Options;
            for (int i = 0; i < Continents.Count; i++)
            {
                Console.WriteLine(Continents[i].Text);
            }
            Console.WriteLine("https://atidcollege.co.il/Xamples/ex_controllers.html?firstname=Igor&lastname=Khaykin&sex=Male&exp=1&datepicker=&photo=&continents=austria&submit=");

            driver.FindElement(By.Id("submit")).Submit();

         
            string currentUrl = driver.Url;
            if (currentUrl.Contains("firstname=Igor") & currentUrl.Contains("lastname=Khaykin"))
                {
                Console.WriteLine("Test Passed");
                }
            else
            {
                Console.WriteLine("Test Failed");
            }

        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

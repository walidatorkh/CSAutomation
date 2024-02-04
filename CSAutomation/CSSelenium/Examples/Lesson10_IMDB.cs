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
    class Lesson10_IMDB
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void StartSesion()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Position = new Point(0, 0);
            //driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Navigate().GoToUrl("http://imdb.com");
        }

        [Test]
        public void Test01_VerifyUrl()
        {
            if(driver.Url.Equals("https://www.imdb.com/"))
                Console.WriteLine("URL passed");
            else Console.WriteLine("Url failed");
        }

        [Test]
        public void Test02_VerifyTitle()
        {
            if (driver.Title.Equals("IMDb: Ratings, Reviews, and Where to Watch the Best Movies & TV Shows"))
                Console.WriteLine("Title passed");
            else Console.WriteLine("Title failed");
        
        }

        [OneTimeTearDown]
        public void CloseSesion()
        {
            driver.Quit();
        }
    }
}

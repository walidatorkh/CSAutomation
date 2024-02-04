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
    class Exercise_TestCaseExample
    {

        IWebDriver driver;

        public Point Locator { get; private set; }

        IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/camera-photo");
        }

        [Test]
        public void Test01FilterPriceAndCountQuantity()
        {
            IWebElement sorting = driver.FindElement(By.Id("products-orderby"));
            SelectElement sort = new SelectElement(sorting);
            sort.SelectByText("Price: Low to High");
            //count products
            int actual = driver.FindElements(By.ClassName("item-box")).Count;
            Assert.AreEqual(3, actual);

        }

        [Test]
        public void Test02ValidateNamesEqualToExpected()
        {
            string[] expectedItems = { "Nikon D5500 DSLR", "Apple iCam", "Leica T Mirrorless Digital Camera" };
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-title"));
            for(int i = 0; i <products.Count; i++)
            {
                Console.WriteLine(products[i].FindElement(By.TagName("a")).Text);
                Assert.AreEqual(expectedItems[i], products[i].FindElement(By.TagName("a")).Text);
            }

        }

        [Test]
        public void Test03ValidateStars()

        {
            string value;
            IList<IWebElement> stars = driver.FindElements(By.XPath("//div[@class='rating']/div"));
            for(int i = 0; i < stars.Count; i++)
            {
                value = stars[i].GetAttribute("style").Replace(" ", "").Split(':')[1].Split('%')[0];
                Console.WriteLine(stars[i].GetAttribute("style"));
                Console.WriteLine(value);
                Assert.True(Int32.Parse(value) >= 60);
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

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace CSSelenium.Examples
{

    [TestFixture]
    internal class Lesson20_NopCommerse
    {
        IWebDriver driver;
        //IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/camera-photo");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

        }

        [Test]
        public void Test01_VerifyURL()
        {
            IWebElement sorting = driver.FindElement(By.Id("products-orderby"));
            SelectElement sort = new SelectElement(sorting);
            sort.SelectByText("Price: Low to High");
            int actual = driver.FindElements(By.ClassName("item-box")).Count;
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void Test02_VerifyNamesOfProducts()
        {
            string[] expectedItems = { "Leica T Mirrorless Digital Camera", "Nikon D5500 DSLR", "Apple iCam" };
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-title"));
            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].FindElement(By.TagName("a")).Text);
                Assert.AreEqual(expectedItems[i], products[i].FindElement(By.TagName("a")).Text);
            }
        }

        [Test]
        public void Test03_VerifyByStars()
        {
            string value;
            IList<IWebElement> stars = driver.FindElements(By.XPath("//div[@class='rating']/div"));
            for (int i = 0; i < stars.Count; i++)
            {
                value = stars[i].GetAttribute("style").Replace(" ", "").Split(':')[1].Split('%')[0];
                Console.WriteLine(stars[i].GetAttribute("style"));
                Console.WriteLine(value);
                Assert.True(Int32.Parse(value) >= 0);
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

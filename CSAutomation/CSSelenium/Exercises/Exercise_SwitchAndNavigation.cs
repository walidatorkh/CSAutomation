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
using System.Threading;
using System.Threading.Tasks;

namespace CSSelenium.Exercises
{
    [TestFixture]
    class Exercise_SwitchAndNavigation
    {
        static String mainTitle = "Switch and Navigate";
        IWebDriver driver;

        public Point Locator { get; private set; }

        IWebElement elem;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://atidcollege.co.il/Xamples/ex_switch_navigation.html");
        }

        [Test]
        public void Test01ShowAlert()
        {
            driver.FindElement(By.Id("btnAlert")).Click();
            IAlert popup = driver.SwitchTo().Alert();
            string text = popup.Text;
            Console.WriteLine("Printing text of popup: " + text);
            popup.Accept();
            //Assert.AreEqual(3, actual);

        }

        [Test]
        public void Test02ShowPrompt()
        {
            //string element;
           driver.FindElement(By.Id("btnPrompt")).Click();
            Thread.Sleep(1000);
            IAlert popup = driver.SwitchTo().Alert();
            popup.SendKeys("ZOPA");
            Console.WriteLine("Prompt text is: " + popup.Text);
            popup.Accept();
            string output = "ZOPA";
            Assert.AreEqual(output, driver.FindElement(By.Id("output")).Text);
            Console.WriteLine("zopa");
  
        }

        [Test]
        public void Test03IFrame()
        {
            IWebElement iFrameElement = driver.FindElement(By.XPath("//*[@id='contact_info_left']/iframe"));
            Thread.Sleep(1000);
            driver.SwitchTo().Frame(iFrameElement);
            Console.WriteLine("iFrameElement text: " + driver.FindElement(By.Id("iframe_container")).Text);
            //Console.WriteLine("iFrameElement text byXpath : " + driver.FindElement(By.XPath("//*[@id='iframe_container']/text()")));
            driver.SwitchTo().DefaultContent();
            Assert.AreEqual(mainTitle, driver.FindElement(By.Id("title")).Text);
        }

        [Test]
        public void Test04SwichTabs()
        {
            driver.FindElement(By.Id("btnNewTab")).Click();
            Thread.Sleep(1000);
            var winHandle1 = driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(winHandle1));
            driver.SwitchTo().Window(winHandle1);
            string output = "This is a new tab";
            Assert.AreEqual(driver.FindElement(By.Id("new_tab_container")).Text, output);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            Assert.AreEqual(driver.FindElement(By.Id("title")).Text, "Switch and Navigate");

            //IReadOnlyCollection<string> winHandles = driver.WindowHandles;
            //foreach(string winHandle in driver.WindowHandles)
            //{
            //    driver.SwitchTo().Window(winHandle);
            //}

            //driver.SwitchTo().Window(handle);

        }


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }
    }
}

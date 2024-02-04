using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSelenium.Exercises
{
	
		[TestFixture]

		public class Exercise_Locators
		{
			IWebDriver driver;
			//IWebElement elem;

			[OneTimeSetUp]
			public void LoadDriver()
			{
				driver = new ChromeDriver();
				driver.Manage().Window.Maximize();
				driver.Navigate().GoToUrl("https://selenium.dev/");
			}

        [Test]
        public void Test01_ByLinkText()
        {
			Console.WriteLine(driver.FindElement(By.LinkText("About")));
        }

        [Test]
		public void Test02_ByClassName()
		{
			Console.WriteLine(driver.FindElement(By.ClassName("selenium - button selenium text - uppercase font - weight - bold")));
		}

		[Test]
		public void Test03_ByName()
		{
			Console.WriteLine(driver.FindElement(By.Name("Blog")));
		}

		[Test]
		public void Test04_ByTagName()
		{
			Console.WriteLine(driver.FindElement(By.TagName("span")));
		}

		[OneTimeTearDown]
			public void UnloadDriver()
			{
				driver.Quit();
			}
		}
	}

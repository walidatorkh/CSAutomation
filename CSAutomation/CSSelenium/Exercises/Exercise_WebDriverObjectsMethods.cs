using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Drawing;

namespace CSSelenium.Exercises
{
	[TestFixture]

	public class Exercise_WebDriverObjectsMethods
	{
		IWebDriver driver;

		[OneTimeSetUp]
		public void LoadDriver()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("http://imdb.com");
		}

		[Test]
		public void Test01_OpenChromeValidateTitle()
        {
			string expectedTile = "IMDb: Ratings, Reviews, and Where to Watch the Best Movies & TV Shows";
            Console.WriteLine("expectedTile:" + expectedTile);
			//driver.Manage().Window.Position = new Point(0, 0);
			//driver.Manage().Window.Size = new Size(1920, 1080);
			driver.Navigate().Refresh();
			string title = driver.Title;
			Console.WriteLine("Title is: " + driver.Title);
			bool result = title.Equals(expectedTile);
			if (!result)
            {
				Console.WriteLine("Result of compare Titles: FAILED " + result);
			}
			else
            {
				Console.WriteLine("Result of compare Titles: SUCCESS " + result);
			}
		}

		[Test]
		public void Test01_OpenChromeValidateUrl()
		{
			string expectedUrl = "https://www.imdb.com/";
			//driver.Manage().Window.Position = new Point(0, 0);
			//driver.Manage().Window.Size = new Size(1920, 1080);
			driver.Navigate().Refresh();
			string url = driver.Url;
			Console.WriteLine("URL is: " + driver.Url);
			bool result = url.Equals(expectedUrl);
			Console.WriteLine("expectedUrl " + expectedUrl);
            Console.WriteLine("url:" + url);
			if (!result)
			{
				Console.WriteLine("Result of compare URL's: FAILED " + result);
			}
			else
			{
				Console.WriteLine("Result of compare URL's: SUCCESS " + result);
			}

		}

		[OneTimeTearDown]
		public void UnloadDriver()
		{
			driver.Quit();
		}
	}
}

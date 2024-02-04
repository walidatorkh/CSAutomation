using Allure.Commons;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using NUnit.Allure.Core;
using Parameter = Allure.Net.Commons.Parameter;

namespace CSSelenium.Exercises
{

    [TestFixture]
    [AllureNUnit]
    [Category("Actions")]
    internal class Exercise_Actions
    { 
        IWebDriver driver;
        WebDriverWait wait;
        IWebElement list1;

        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GetData("URL"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //string testName = TestContext.CurrentContext.Test.Name.Split('_')[0];
            //string testDescription = TestContext.CurrentContext.Test.Name.Split('_')[1];
        }

        [Test(Description = "Sanity Actions!")]
        [Category("Test01_FindDropped")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #1")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test FindDropped")]
        [AllureSubSuite("Sub Suite")]
        public void Test01_FindDropped()
        {

            try 
            {  
                Thread.Sleep(1000);
                IWebElement draggable = driver.FindElement(By.Id("draggable"));
                IWebElement droppable = driver.FindElement(By.Id("droppable"));
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Perform step drag and drop",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                {
                    Actions action = new Actions(driver);
                    action.DragAndDrop(draggable, droppable).Build().Perform();
                }
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Step drag and drop done",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                Thread.Sleep(1000);

                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Wait to find elements",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                {
                    driver.FindElement(By.XPath("//*[@id='droppable']/p")).Equals("Dropped!");
                }
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Element found and equals to Dropped!",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity Actions!")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #2")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test SelectElements")]
        public void Test02_SelectElements()
        {
            try
            {
                //AllureLifecycle.Instance.WrapInStep(() =>
                {
                    Thread.Sleep(1000);
                    //} "Waiting for start");
                    IList<IWebElement> list1 = driver.FindElements(By.XPath("//*[@id='select_items']/li"));
                    //AllureLifecycle.Instance.WrapInStep(() =>
                    {
                        Actions action = new Actions(driver);
                        action.ClickAndHold(list1[1]);
                        action.ClickAndHold(list1[2]);
                        action.Build().Perform();
                        //} "Action Click&Hold 2 items");
                        Console.WriteLine("Test passed");
                        IList<IWebElement> list2 = driver.FindElements(By.Id("ui-widget-content ui-selectee ui-selected"));
                        for (int i = 0; i < list2.Count; i++)
                        {
                            Console.WriteLine(list2[i].Text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity Actions!")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #3")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test DoubleClick")]
        public void Test03_DoubleClick()
        {
            try
            {
                Thread.Sleep(1000);
                IWebElement dClick = driver.FindElement(By.Id("dbl_click"));
                Actions action = new Actions(driver);
                action.DoubleClick(dClick);
                action.Build().Perform();
                string hiddenElement = driver.FindElement(By.Id("demo")).Text;
                string ExpectedMessage = "Hello World";
                Assert.AreEqual(hiddenElement, ExpectedMessage);
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity Actions!")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #4")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test MouseHover")]
        public void Test04_MouseHover()
        {
            try
            {
                Thread.Sleep(1000);
                Actions action = new Actions(driver);
                IWebElement elem1 = driver.FindElement(By.Id("mouse_hover"));
                string BgroundColor = driver.FindElement(By.Id("mouse_hover")).GetCssValue("background-color");
                Console.WriteLine("background-color: " + BgroundColor);
                action.MoveToElement(elem1);
                action.Build().Perform();
                string hiddenBgroundColor = driver.FindElement(By.Id("mouse_hover")).GetCssValue("background-color");
                Console.WriteLine("background-color: " + hiddenBgroundColor);
                Assert.AreNotEqual(BgroundColor, hiddenBgroundColor);
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity Actions!")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #5")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test ScrollPage1")]
        public void Test05_ScrollPage1()
        {
            try
            {
                string expectedElem = "This Element is Shown When Scrolled";
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)driver).ExecuteScript("scrollTo(0, 1000)");
                Thread.Sleep(3000);
                string elem1 = driver.FindElement(By.Id("scrolled_element")).Text;
                Assert.AreEqual(expectedElem, elem1); 
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity Actions!")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #6")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test ScrollPage2")]
        public void Test06_ScrollPage2()
        {
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                IWebElement elem1 = driver.FindElement(By.Id("scrolled_element"));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elem1);
                Thread.Sleep(3000);
                string expectedElem = "This Element is Shown When Scrolled";
                string actualElem = elem1.Text;
                Assert.AreEqual(expectedElem, actualElem);
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [Test(Description = "Sanity_Actions")]
        [AllureSeverity(Allure.Net.Commons.SeverityLevel.critical)]
        [AllureIssue("Issue #7")]
        [AllureTms("Teams")]
        [AllureOwner("I'm Owner")]
        [AllureStep("Test Negative ScrollPage2")]
        [Category("ActionsNegative")]
        public void Test07_NegativeTest()
        {
            try
            {
                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                IWebElement elem1 = driver.FindElement(By.Id("scrolled_element"));
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Finding scrolled_element",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                js.ExecuteScript("arguments[0].scrollIntoView(true);", elem1);
                Thread.Sleep(3000);
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Executed scrolling",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                string expectedElem = "This Element is Shown When Scrolled!!!";
                string actualElem = elem1.Text;
                Assert.AreEqual(expectedElem, actualElem);
                Allure.Net.Commons.AllureLifecycle.Instance.UpdateStep(stepResult =>
                           stepResult.parameters.Add(
                               new Parameter
                               {
                                   name = "Compare expected against exist",
                                   value = DateTime.Now.ToString()
                               }
                           )
                       );
                Console.WriteLine("Test passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test failed, details in: " + e.Message);
                Assert.Fail("Assert.Fail details in: " + e.Message);
            }
        }

        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Quit();
        }

        public string GetData(string nodeName)
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Automation\CSAutomation\CSAutomation\CSSelenium\externalData\dataActions.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.ToString().Equals(nodeName))
                            return reader.ReadString();
                    }
                }
            }
            return "NULL";
        }
    }
}

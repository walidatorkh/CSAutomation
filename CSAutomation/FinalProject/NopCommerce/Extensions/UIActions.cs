using FinalProject.NopCommerce.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;


namespace FinalProject.NopCommerce.Extensions
{
    class UIActions : CommonOps
    {
        public static void Click(IWebElement elem) 
        {
            try
            {
                elem.Click();
                Console.WriteLine("Clicked successfully");
                test.Log(LogStatus.Pass, "Clicked successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Click failed " + e.Message);
                test.Log(LogStatus.Fail, "Click failed " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Click failed " + e.Message);
            }
        }
        public static void UpdateText(IWebElement elem, string text)
        {
            try
            {
                //Explicit wait (Text to be present in element located...)
                elem.SendKeys(text);
                Console.WriteLine("Text Updated successfully");
                test.Log(LogStatus.Pass, "Text Updated successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine("Text Update failed " + e.Message);
                test.Log(LogStatus.Fail, "Text Update failed " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Text Update failed " + e.Message);
            }
        }
        public static void UpdateDropDown(IWebElement elem, string text)
        {
            try
            {
                //Explicit wait (Element to be visible...)
                SelectElement dropDown = new SelectElement(elem);
                dropDown.SelectByText(text);
                Console.WriteLine("Drop Down Updated successfully");
                test.Log(LogStatus.Pass, "Drop Down Updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Drop Down Updated failed " + e.Message);
                test.Log(LogStatus.Fail, "Drop Down Updated failed " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Drop Down Updated failed " + e.Message);
            }
        }
        public static void UpdateDropDown(IWebElement elem, int index)
        {
            try
            {
                //Explicit wait (Element to be visible...)
                SelectElement dropDown = new SelectElement(elem);
                dropDown.SelectByIndex(index);
                Console.WriteLine("Drop Down Updated successfully");
                test.Log(LogStatus.Pass, "Drop Down Updated successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine("Drop Down Updated failed " + e.Message);
                test.Log(LogStatus.Fail, "Drop Down Updated failed " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Drop Down Updated failed " + e.Message);
            }
        }

        public static int GetListCount(IList<IWebElement> elems)
        {
            return elems.Count;
        }

        public static void UpdateMouseHover(IWebElement elem)
        {
            try
            {
                Thread.Sleep(1000);
                Actions action = new Actions(driver);
                action.MoveToElement(elem);
                action.Build().Perform();
                Console.WriteLine("Update Mouse Hover successfully ");
                test.Log(LogStatus.Pass, "Update Mouse Hover successfully ");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                test.Log(LogStatus.Fail, "Update Mouse Hover failed " + e.Message + test.AddScreenCapture(ScreenShot()));
                Assert.Fail("Update Mouse Hover failed " + e.Message);
            }
        }
    }
}

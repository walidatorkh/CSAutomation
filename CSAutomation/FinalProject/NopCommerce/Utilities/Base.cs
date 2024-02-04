using FinalProject.NopCommerce.PageObjects;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;

namespace FinalProject.NopCommerce.Utilities
{
    class Base
    {
        protected static IWebDriver driver;
        protected static ExtentReports extent;
        protected static ExtentTest test;
        protected static string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        //page objects
        protected static Items items;
        protected static SortDisplay sortDisplay;
        protected static TopMenu topMenu;   
    }
}

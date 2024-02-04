using FinalProject.NopCommerce.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalProject.NopCommerce.PageObjects
{
    class SortDisplay : CommonOps
    {
        public SortDisplay()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        [FindsBy(How = How.Id, Using = "products-pagesize")]
        public IWebElement drop_Display;

        [FindsBy(How = How.CssSelector, Using = "body > div.master-wrapper-page > div.master-wrapper-content > div > div.center-2 > div")]//div[class='page-title'] h1
        public IList<IWebElement> counted_Categories;
    }
}

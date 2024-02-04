using FinalProject.NopCommerce.Utilities;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports.Model;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalProject.NopCommerce.PageObjects
{
    class Items : CommonOps
    {
        public Items()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        [FindsBy(How = How.ClassName, Using = "item-box")]
        public IList<IWebElement> list_Items;

        [FindsBy(How = How.LinkText, Using = "Show products in category Shoes")]
        public IWebElement link_Show_products_Shoes;

        [FindsBy(How = How.LinkText, Using = "Shoes")]
        public IWebElement link_Show_Shoes;

        [FindsBy(How = How.ClassName, Using = "item-grid")]
        public IList<IWebElement> link_Exists_Products;

        [FindsBy(How = How.LinkText, Using = "Show products in category Clothing")]
        public IWebElement link_Show_products_Clothing;

        [FindsBy(How = How.LinkText, Using = "Show products in category Accessories")]
        public IWebElement link_Show_products_Accessories;
    }
}

using FinalProject.NopCommerce.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace FinalProject.NopCommerce.PageObjects
{
    class TopMenu : CommonOps
    {
        public TopMenu()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(Convert.ToDouble(GetData("TIME_OUT")))));
        }

        [FindsBy(How = How.LinkText, Using = "Books")]
        public IWebElement link_Books;

        [FindsBy(How = How.LinkText, Using = "Computers")]
        public IWebElement link_Computers;

        [FindsBy(How = How.LinkText, Using = "Electronics")]
        public IWebElement link_Electronics;

        [FindsBy(How = How.LinkText, Using = "Apparel")]
        public IWebElement link_Apparel;

        [FindsBy(How = How.LinkText, Using = "Digital downloads")]
        public IWebElement link_Digital_downloads;

        [FindsBy(How = How.LinkText, Using = "Jewelry")]
        public IWebElement link_Jewelry;

        [FindsBy(How = How.LinkText, Using = "Gift Cards")]
        public IWebElement link_Gift_Cards;
    }
}

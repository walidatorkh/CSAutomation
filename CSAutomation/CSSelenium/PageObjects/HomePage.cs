using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSSelenium.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(1)));
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn_primary btn_small btn_inventory ']")]
        //
        private IList<IWebElement> list_btn_AddToCart;

        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn_secondary btn_small btn_inventory ']")]
        private IList<IWebElement> list_btn_RemoveFromCart;

        [FindsBy(How = How.CssSelector, Using = "span[class='shopping_cart_badge']")] //.shopping_cart_link
        private IList<IWebElement> list_icon_Cart;

        public void AddToCart(int index)
        {
            Console.WriteLine($"index of AddToCart: [{index}]");
            list_btn_AddToCart[index].Click();
        }
        public void RemoveFromCart(int index)
        {
            Console.WriteLine($"index of RemoveFromCart: [{index}]");
            list_btn_RemoveFromCart[index].Click();
        }
        

        public void VerifyItemsInCart(int expected)
        {
            if (expected == 0)
            {
                Assert.True(list_icon_Cart.Count == 0);
            }
            else
            {
                Assert.AreEqual(expected.ToString(), list_icon_Cart[0].Text);
            }
        }
    }
}

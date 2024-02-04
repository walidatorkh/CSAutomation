using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CSSelenium.PageObjectsExercise
{
    class AfterLoginPage
    {
        private IWebDriver driver;
        public AfterLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(1)));
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > table > tbody > tr:nth-child(2) > td > a > button")]
        private IWebElement buttonClickMe;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div/img")]
        private IWebElement chromeSearchExist;

        public void AfterLoginAction()
        {
            buttonClickMe.Click();
            Thread.Sleep(2000);
            Assert.True(chromeSearchExist.Displayed);
        }

    }
}

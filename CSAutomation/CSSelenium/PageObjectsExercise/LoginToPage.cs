using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace CSSelenium.PageObjectsExercise
{
    class LoginToPage
    {
        private IWebDriver driver;
        public LoginToPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(1)));
        }

        [FindsBy(How = How.Name, Using = "username2")]
        private IWebElement textBox_username;

        [FindsBy(How = How.Name, Using = "password2")]
        private IWebElement textBox_password;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement button_submit;

        //string user = "selenium";
        //string password = "webdriver";
        public void LoginAction(string user, string password)
        {
            textBox_username.SendKeys(user);
            textBox_password.SendKeys(password);
            button_submit.Click();
        }

    }
}

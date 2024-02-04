using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace CSSelenium.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(1)));
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement txt_UserName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txt_Password;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement btn_Login;

        public void LoginAction(string user, string password)
        {
            txt_UserName.Clear();
            txt_UserName.SendKeys(user);
            txt_Password.Clear();
            txt_Password.SendKeys(password);
            btn_Login.Click();
        }
    }
}

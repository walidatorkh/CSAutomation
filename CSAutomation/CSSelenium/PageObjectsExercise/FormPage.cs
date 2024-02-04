using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CSSelenium.PageObjectsExercise
{
    class FormPage
    {
        private IWebDriver driver;

        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(1)));
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='occupation'] ")]
        private IWebElement textBox_Occupation;

        [FindsBy(How = How.XPath, Using = "//*[@id='age']")]
        private IWebElement textBox_Age;

        [FindsBy(How = How.Id, Using = "location")]
        private IWebElement textBox_Location;

        [FindsBy(How = How.XPath, Using = "//*[@id='contact_form']/fieldset/ol/li[4]/a/input")]
        private IWebElement button_ClickMe;


        public void AddFormAction(string occupation, string age, string location)
        {
            textBox_Occupation.SendKeys(occupation);
            textBox_Age.SendKeys(age);
            textBox_Location.SendKeys(location);
            Thread.Sleep(5000);
            button_ClickMe.Click();
        }
    }
}

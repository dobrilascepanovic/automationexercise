﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFreework.Helpers
{
    public class Utilities
    {
        readonly IWebDriver _driver;
        private static readonly Random RandomName = new Random();



        public Utilities(IWebDriver driver)
        {
            this._driver = driver;

        }

        public string GenerateRendomEmail()
        {
            return string.Format("email{0}@mailinator.com", RandomName.Next(1000, 10000));
        }


        public void ClickOnElement(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator)).Click();
        }

        public void EnterTextInElement(By locator, string text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).SendKeys(text);
        }
        public bool ElementIsDisplayed(By selector)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector)).Displayed;

        }
        public void DropdownSelect(By select, string option)
        {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(select));
        var dropdown = _driver.FindElement(select);
        var selectElement = new SelectElement(dropdown);
        selectElement.SelectByValue(option);
        }

        internal void ClickOnElement(object viewCart)
        {
            throw new NotImplementedException();
        }

        internal string ReturnTextElement(object prodName)
        {
            throw new NotImplementedException();
        }

        internal void ClickOnElement(object vieWCard)
        {
            throw new NotImplementedException();
        }

        public bool TextPresentInElement(string text)
        {
            By headline = By.XPath("//*[contains(text(),'" + text + "')]");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(headline)).Displayed;


        }
        public string ReturnTextElement(By locator)

        {
            return _driver.FindElement(locator).GetAttribute("textContent");
            //return _driver.FindElement(locator).Text;
        }

    }
}

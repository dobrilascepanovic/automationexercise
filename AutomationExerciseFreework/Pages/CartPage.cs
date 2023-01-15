using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFreework.Pages
{
    class CartPage
    {
        
        public IWebDriver _driver;
        public By cartLink = By.ClassName("fa-shopping-cart");
        public By insidecart = By.XPath("//body/section[@id='cart_items']/div[1]");
        

        public CartPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(cartLink));

        }

    }

}

    


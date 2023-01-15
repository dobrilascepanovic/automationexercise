using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationExerciseFreework.Pages
{
    class ProductDetalsPage
    {
        public IWebDriver _driver;
        public By prodDetInfo = By.ClassName("product-information");
        public By addTocartBtn = By.ClassName("btn-default cart");
        public By viewCard = By.ClassName("fa-shopping-cart");
        public By container = By.Id("checkoutModal");
        public By prodName = By.XPath("//h2[contains(text(),'Blue Top')]");

        public ProductDetalsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(prodDetInfo));

        }

    }
  
}

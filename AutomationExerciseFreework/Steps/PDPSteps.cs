using AutomationExerciseFreework.Helpers;
using AutomationExerciseFreework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFreework.Steps 
{
    [Binding]
    public class PDPSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        private readonly ProductDate productDate;

        public PDPSteps (ProductDate productDate)
        {
            this.productDate = productDate;
        }


        [Given(@"user opens products page")]
        public void GivenUserOpensProductsPage()
        {
            ut.ClickOnElement(hp.product);

        }
        
        [Given(@"searches for '(.*)' term")]
        public void GivenSearchesForTerm(string searchedTer)
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.EnterTextInElement(pp.searchInput, searchedTer);
            ut.ClickOnElement(pp.searchBtn);
        }
        
        [Given(@"opens first search result")]
        public void GivenOpensFirstSearchResult()
        {
            ProductsPage pp = new ProductsPage(Driver);
            ut.ClickOnElement(pp.viewProdBtn);
        }
        
        [When(@"user click on Add to Cart button")]
        public void WhenUserClickOnAddToCartButton()
        {
            ProductDetalsPage pdp = new ProductDetalsPage(Driver);
            productDate.ProductName = ut.ReturnTextFromElement(pdp.prodName);
            ut.ClickOnElement(pdp.addTocartBtn);
        }
        
        [When(@"proceeds to cart")]
        public void WhenProceedsToCart()
        {
            ProductDetalsPage pd = new ProductDetalsPage(Driver);
            ut.ClickOnElement(pd.viewCard);
        }
        
        [Then(@"shoppig cart will be displayed with expected  product inside")]
        public void ThenShoppigCartWillBeDisplayedWithProductInside(string pageFound)
        {
            CartPage cp = new CartPage(Driver);
            Assert.True(ut.TextPresentInElement(productDate.ProductName), "Desierd product Not find");
           
        }

        
        }
    }


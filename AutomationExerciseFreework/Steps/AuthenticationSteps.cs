using AutomationExerciseFreework.Helpers;
using AutomationExerciseFreework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFreework.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);


        [Given(@"user opens sing in page")]
        public void GivenUserOpensSingInPage()

        {
            ut.ClickOnElement(hp.loginLink);

        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()

        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.loginEmail, TestConstants.Username);
            ut.EnterTextInElement(ap.loginPassword, TestConstants.Passvord);
        }
        
        [When(@"user submits login form")]
        public void WhenUserSubmitsLoginForm()
        {
           AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementIsDisplayed(hp.deleteAcc),"User is NOT logged in");
        }

        [Given(@"enters'(.*)'name and valid email addres")]
        public void GivenEntersNameAndValidEmailAddres(string name)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.name, name);
            ut.EnterTextInElement(ap.sugnupEmail, ut.GenerateRendomEmail());
        }

        [Given(@"user clicks on SingnUp button")]
        public void GivenUserClicksOnSingnUpButton()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            
            ut.ClickOnElement(ap.signupBtn);
        }

        [When(@"user fills in all requires fields")]
        public void WhenUserFillsInAllRequiresFields()
        {
            SignupPage sp = new SignupPage(Driver);
            ut.EnterTextInElement(sp.paddword, TestConstants.Passvord);
            ut.EnterTextInElement(sp.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sp.lastName, TestConstants.LastName);
            ut.EnterTextInElement(sp.adress, TestConstants.Address);
            ut.DropdownSelect(sp.country, TestConstants.Country);
            ut.EnterTextInElement(sp.city, TestConstants.City);
            ut.EnterTextInElement(sp.zipcode, TestConstants.ZipCode);
            ut.EnterTextInElement(sp.mobile, TestConstants.Phone);

        }

        [When(@"submits the signup form")]
        public void WhenSubmitsTheSignupForm()
        {
            SignupPage sp = new SignupPage(Driver);
            Driver.FindElement(sp.form).Submit();
            //ut.ClickOnElement(sp.creatAcc);
        }

        [Then(@"user will get '(.*)' success message")]
        public void ThenUserWillGetSuccessMessage(string message)

        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentInElement(message),"User did NOT get expected success message");
            ut.ClickOnElement(acp.continueBtn);

        }

    }
}

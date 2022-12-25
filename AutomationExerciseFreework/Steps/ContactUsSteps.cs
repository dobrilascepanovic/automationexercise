using AutomationExerciseFreework.Helpers;
using AutomationExerciseFreework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationExerciseFreework.Steps
{
    [Binding]
    public class ContactUsSteps : Base

    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"user opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            ut.ClickOnElement(hp.contactLink);
        }
        
        [When(@"user enters all required fields")]
        public void WhenUserEntersAllRequiredFields()
        {
            ContactUsPage cup = new ContactUsPage(Driver);

            ut.EnterTextInElement(cup.name, TestConstants.FirstName + " " + TestConstants.LastName);
            ut.EnterTextInElement(cup.email, TestConstants.Username);
            ut.EnterTextInElement(cup.subjekt, TestConstants.Subjekt);
            ut.EnterTextInElement(cup.message, TestConstants.Message);

        }
        
        [When(@"user submits contact us form")]
        public void WhenUserSubmitsContactUsForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            Driver.FindElement(cup.form).Submit();
        }
        
        [When(@"confirms the promt message")]
        public void WhenConfirmsThePromtMessage()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
        
        [Then(@"user will receive '(.*)'massage")]
        public void ThenUserWillReciveMassage(string succesMessage)
        {
            Assert.True(ut.TextPresentInElement(succesMessage), "User's message was not  sent successfully vai contact");
        }
    }
}

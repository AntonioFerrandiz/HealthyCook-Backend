using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class RegisterUserSteps
    {
        [Given(@"the user wants to register")]
        public void GivenTheUserWantsToRegister()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"goes to the account registration window")]
        public void GivenGoesToTheAccountRegistrationWindow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the user enters his email address")]
        public void GivenTheUserEntersHisEmailAddress()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"it is already in use by another user")]
        public void GivenItIsAlreadyInUseByAnotherUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user fills in the form with the requested information")]
        public void WhenTheUserFillsInTheFormWithTheRequestedInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user does not successfully confirm his password")]
        public void WhenTheUserDoesNotSuccessfullyConfirmHisPassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user will be successfully registered")]
        public void ThenTheUserWillBeSuccessfullyRegistered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a warning message will be displayed on the password input")]
        public void ThenAWarningMessageWillBeDisplayedOnThePasswordInput(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"you will not be able to register and a message will be displayed")]
        public void ThenYouWillNotBeAbleToRegisterAndAMessageWillBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

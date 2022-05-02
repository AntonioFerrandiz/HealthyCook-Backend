using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class ViewRestaurantReviewSteps
    {
        [Given(@"the restaurant owner goes to the ""(.*)"" window")]
        public void GivenTheRestaurantOwnerGoesToTheWindow(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"then to the ""(.*)"" section")]
        public void GivenThenToTheSection(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"that the owner of the restaurant is in the reviews section")]
        public void GivenThatTheOwnerOfTheRestaurantIsInTheReviewsSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"there are no reviews")]
        public void GivenThereAreNoReviews()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the restaurant owner presses the ""(.*)"" button")]
        public void WhenTheRestaurantOwnerPressesTheButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"will be redirected to the reviews section where the restaurant owner will be able to see the reviews\.")]
        public void ThenWillBeRedirectedToTheReviewsSectionWhereTheRestaurantOwnerWillBeAbleToSeeTheReviews_(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a message will  be displayed")]
        public void ThenAMessageWillBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

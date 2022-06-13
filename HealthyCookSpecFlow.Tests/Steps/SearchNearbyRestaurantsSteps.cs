using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class SearchNearbyRestaurantsSteps
    {
        [Given(@"that the user is in the restaurants section")]
        public void GivenThatTheUserIsInTheRestaurantsSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user goes to the search bar for restaurants")]
        public void WhenTheUserGoesToTheSearchBarForRestaurants()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"there is no restaurant near your location")]
        public void WhenThereIsNoRestaurantNearYourLocation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"will then be presented with restaurants near your current location")]
        public void ThenWillThenBePresentedWithRestaurantsNearYourCurrentLocation(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user will then be notified that there is no restaurant available nearby\.")]
        public void ThenTheUserWillThenBeNotifiedThatThereIsNoRestaurantAvailableNearby_(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

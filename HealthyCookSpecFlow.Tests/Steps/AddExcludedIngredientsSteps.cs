using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class AddExcludedIngredientsSteps
    {
        [Given(@"a user is wants to add an ingredient to his list of excluded ingredients")]
        public void GivenAUserIsWantsToAddAnIngredientToHisListOfExcludedIngredients()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user adds a new ingredient to the list")]
        public void WhenTheUserAddsANewIngredientToTheList(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the ingredient will then be added to your list of excluded ingredients\.")]
        public void ThenTheIngredientWillThenBeAddedToYourListOfExcludedIngredients_(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

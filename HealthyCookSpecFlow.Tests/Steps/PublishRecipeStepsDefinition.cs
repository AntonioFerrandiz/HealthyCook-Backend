using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class PublishRecipeStepsDefinition
    {
        [Given(@"a user wants to add a recipe")]
        public void GivenAUserWantsToAddARecipe()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"user add a new recipe")]
        public void WhenUserAddANewRecipe(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the recipe will be published successfully")]
        public void ThenTheRecipeWillBePublishedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"does not complete the recipe description field")]
        public void GivenDoesNotCompleteTheRecipeDescriptionField()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"an error message will be displayed")]
        public void ThenAnErrorMessageWillBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}

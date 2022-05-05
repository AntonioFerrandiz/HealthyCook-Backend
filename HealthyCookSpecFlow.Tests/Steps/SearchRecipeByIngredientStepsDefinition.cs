using System;
using TechTalk.SpecFlow;

namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class SearchRecipeByIngredientStepsDefinition
    {
        [Given(@"the first ingredient is egg")]
        public void GivenTheFirstIngredientIsEgg()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the second ingredient is potatoes")]
        public void GivenTheSecondIngredientIsPotatoes()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the ingredient is kiwi")]
        public void GivenTheIngredientIsKiwi()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"user searches for recipes without selecting ingredients")]
        public void GivenUserSearchesForRecipesWithoutSelectingIngredients(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he presses the button ""(.*)""\.")]
        public void WhenHePressesTheButton_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"will then be shown a list of recipes that he can cook with the selected ingredients\.")]
        public void ThenWillThenBeShownAListOfRecipesThatHeCanCookWithTheSelectedIngredients_(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a message will be displayed")]
        public void ThenAMessageWillBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a warning message will be displayed")]
        public void ThenAWarningMessageWillBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

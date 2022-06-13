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


        [Given(@"that the user searches for recipes containing chicken")]
        public void GivenThatTheUserSearchesForRecipesContainingChicken()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"recipes are obtained")]
        public void WhenRecipesAreObtained()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"identify which of these contain an excluded ingredient\.")]
        public void WhenIdentifyWhichOfTheseContainAnExcludedIngredient_(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"It will then show a list of recipes allowed for the user")]
        public void ThenItWillThenShowAListOfRecipesAllowedForTheUser(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"another list of recipes excluded by the user's preferences\.")]
        public void ThenAnotherListOfRecipesExcludedByTheUserSPreferences_(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}

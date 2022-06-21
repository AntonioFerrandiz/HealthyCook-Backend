using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using HealthyCook_Backend;
using HealthyCook_Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using ServiceStack;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
namespace HealthyCookSpecFlow.Tests.Steps
{
    [Binding]
    public class AddExcludedIngredientsSteps: WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _client;
        private Uri _baseUri;
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response { get; set; }
        
        public AddExcludedIngredientsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint http://localhost:(.*)/api/ExcludedIngredients is available")]
        public void GivenTheEndpointHttpLocalhostApiExcludedIngredientsIsAvailable(int port)
        {
            _baseUri = new Uri($"http://localhost:{port}/api/ExcludedIngredients");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });
        }

        [When(@"A user add new ingredient to his list")]
        public void WhenAUserAddNewIngredientToHistList(Table savedExcludedIngredientResource)
        {
            var resource = savedExcludedIngredientResource.CreateSet<ExcludedIngredients>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Response with status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.GetAwaiter().GetResult().StatusCode.ToString();
            Assert.AreEqual(expectedStatusCode, actualStatusCode);
        }

        // Scenario 2

        [When(@"A Post Request is sent with IngredientName null")]
        public void WhenAPostRequestIsSentWithIngredientNameNull(Table savedExcludedIngredientResource)
        {
            var resource = savedExcludedIngredientResource.CreateSet<ExcludedIngredients>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        // Scenario 3
        [When(@"A Post request is sent with IngredientName that was already in the list")]
        public void WhenAPostRequestIsSentWithIngredientNameThatWasAlreadyInTheList(Table savedExcludedIngredientResource)
        {
            var resource = savedExcludedIngredientResource.CreateSet<ExcludedIngredients>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }

        [Then(@"A Message of ""(.*)"" is include in response body")]
        public async void ThenAMessageOfIsIncludeInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var stringExpectedMessage = expectedMessage.ToString();
            Assert.AreEqual(stringExpectedMessage, actualMessage);
        }
        // Scenario 4
        [When(@"a user search recipe using an ingredient")]
        public void WhenRecipeSearchUsingAnIngredient(Table ingredients)
        {
            var baseUriForSearch = $"http://localhost:50947/api/Recipe/SearchRecipeByIngredient/{ingredients.Rows[0][0]}/{ingredients.Rows[0][1]}";
            Response = _client.GetAsync(baseUriForSearch).ConfigureAwait(false);

        }

        [Then(@"A RecipeFound Resource is included in Response Body")]
        public async void ThenARecipeFoundResourceIsIncludedInResponseBody(Table expectedRecipeResource)
        {
            var expectedResource = expectedRecipeResource.CreateSet<Recipe>().First();
            var responseData = await Response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<Recipe>(responseData);
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResources = resource.ToJson();
            Assert.AreEqual(jsonExpectedResource, jsonActualResources);
        }

        // Scenario 5
        [When(@"a user searches for a recipe with an ingredient that is on your list of excluded ingredients")]
        public void WhenAUserSearchesForARecipeWithAnIngredientThatIsOnYourListOfExcludedIngredients(Table ingredients)
        {
            var baseUriForSearch = $"http://localhost:50947/api/Recipe/SearchRecipeByIngredient/{ingredients.Rows[0][0]}/{ingredients.Rows[0][1]}";
            Response = _client.GetAsync(baseUriForSearch).ConfigureAwait(false);
        }

    }
}

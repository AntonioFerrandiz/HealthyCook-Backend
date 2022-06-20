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

        [Then(@"A Excluded Ingredient Resource is included in Response Body")]
        public async void ThenAExcludedIngredientResourceIsIncludedInResponseBody(Table expectedExcludedIngredientResource)
        {
            var expectedResource = expectedExcludedIngredientResource.CreateSet<ExcludedIngredients>().First();
            var responseData = await Response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ExcludedIngredients>(responseData);
            expectedResource.ID= resource.ID;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.AreEqual(jsonExpectedResource, jsonActualResource);
        }

        // Scenario 2

        [When(@"A Post Request is sent with IngredientName null")]
        public void WhenAPostRequestIsSentWithIngredientNameNull(Table savedExcludedIngredientResource)
        {
            var resource = savedExcludedIngredientResource.CreateSet<ExcludedIngredients>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(false);
        }
    }
}


using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private ConfiguredTaskAwaitable<HttpResponseMessage> Response
        {
            get;
            set;
        }
        public AddExcludedIngredientsSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Given(@"a user is wants to add an ingredient to his list of excluded ingredients")]
        public void GivenAUserIsWantsToAddAnIngredientToHisListOfExcludedIngredients()
        {
            _baseUri = new Uri($"http://localhost:50947/api/ExcludedIngredients");
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = _baseUri });

        }
        
        [When(@"the user adds a new ingredient to the list")]
        public void WhenTheUserAddsANewIngredientToTheList(Table table)
        {
         
            ExcludedIngredients excludedIngredients = table.CreateSet<ExcludedIngredients>().Single();
            var content = new StringContent(excludedIngredients.ToJson(), Encoding.UTF8, "application/json");
            Response = _client.PostAsync(_baseUri, content).ConfigureAwait(true);
        }

        [Then(@"the ingredient will then be added to your list of excluded ingredients with status (.*)")]
        public void ThenTheIngredientWillThenBeAddedToYourListOfExcludedIngredientsWithStatus(int p0)
        {
            HttpStatusCode statusCode = (HttpStatusCode)p0;
            Console.WriteLine(statusCode);
            Assert.AreEqual(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }

        [Then(@"no ingredient will be added and there will be an error with status (.*)")]
        public void ThenThenNoIngredientWillBeAddedAndThereWillBeAnErrorWithStatus(int p0)
        {
            HttpStatusCode statusCode = (HttpStatusCode)p0;
            Assert.AreEqual(statusCode.ToString(), Response.GetAwaiter().GetResult().StatusCode.ToString());
        }

    }
}

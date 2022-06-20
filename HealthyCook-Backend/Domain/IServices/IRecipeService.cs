using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IRecipeService
    {
        Task CreateRecipe(Recipe recipe);
        Task DeleteRecipe(Recipe recipe);
        Task<Recipe> GetRecipeByID(int recipeID);
        Task<Recipe> ChangePublicationStatus(int recipeID);
        Task<int> GetNumberOfRecipes();
        Task<List<Recipe>> GetLastFiveRecipes();
        Task<List<Recipe>> GetTodaysRecipes(string date);
        Task<List<Recipe>> GetListRecipes();
        Task<List<Recipe>> GetListRecipesPublishedByUser(int userID);
        Task<List<Recipe>> GetListRecipesNoPublishedByUser(int userID);
        Task<List<Recipe>> SearchRecipeByIngredient(string ingredient, string excludedIngredient);
    }
}

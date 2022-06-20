
using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RecipeService: IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<Recipe> ChangePublicationStatus(int recipeID)
        {
            return await _recipeRepository.ChangePublicationStatus(recipeID);
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            await _recipeRepository.CreateRecipe(recipe);
        }

        public async Task<List<Recipe>> GetListRecipes()
        {
            return await _recipeRepository.GetListRecipes();
        }

        public async Task<List<Recipe>> GetListRecipesPublishedByUser(int userID)
        {
            return await _recipeRepository.GetListRecipesPublishedByUser(userID);
        }
        public async Task<List<Recipe>> GetListRecipesNoPublishedByUser(int userID)
        {
            return await _recipeRepository.GetListRecipesNoPublishedByUser(userID);
        }
        
        public async Task<Recipe> GetRecipeByID(int recipeID)
        {
            return await _recipeRepository.GetRecipeByID(recipeID);
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            await _recipeRepository.DeleteRecipe(recipe);
        }

        public async Task<int> GetNumberOfRecipes()
        {
            return await _recipeRepository.GetNumberOfRecipes();
        }

        public async Task<List<Recipe>> GetLastFiveRecipes()
        {
            return await _recipeRepository.GetLastFiveRecipes();
        }

        public async Task<List<Recipe>> GetTodaysRecipes(string date)
        {
            return await _recipeRepository.GetTodaysRecipes(date);
        }

        public async Task<List<Recipe>> SearchRecipeByIngredient(string ingredient, string excludedIngredient)
        {
            return await _recipeRepository.SearchRecipeByIngredient(ingredient, excludedIngredient);
        }
    }
}

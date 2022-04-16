
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

        public async Task CreateRecipe(Recipe recipe)
        {
            await _recipeRepository.CreateRecipe(recipe);
        }

        public async Task<List<Recipe>> GetListRecipes()
        {
            return await _recipeRepository.GetListRecipes();
        }
    }
}

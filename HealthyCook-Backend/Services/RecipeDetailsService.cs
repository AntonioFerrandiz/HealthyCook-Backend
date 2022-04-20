using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RecipeDetailsService : IRecipeDetailsService
    {
        private readonly IRecipeDetailsRepository _recipeDetailsRepository;

        public RecipeDetailsService(IRecipeDetailsRepository recipeDetailsRepository)
        {
            _recipeDetailsRepository = recipeDetailsRepository;
        }

        
        public async Task SaveRecipeDetails(RecipeDetails recipeDetails)
        {
            await _recipeDetailsRepository.SaveRecipeDetails(recipeDetails);
        }
        public async Task<RecipeDetails> GetRecipeDetails(int recipeID)
        {
            return await _recipeDetailsRepository.GetRecipeDetails(recipeID);
        }

        public async Task<RecipeDetails> SearchRecipeDetails(int recipeID)
        {
            return await _recipeDetailsRepository.SearchRecipeDetails(recipeID);
        }
    }
}

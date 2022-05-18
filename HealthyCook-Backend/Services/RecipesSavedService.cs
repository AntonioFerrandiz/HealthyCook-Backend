using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RecipesSavedService : IRecipesSavedService
    {
        private readonly IRecipesSavedRepository _recipesSavedRepository;

        public RecipesSavedService(IRecipesSavedRepository recipesSavedRepository)
        {
            _recipesSavedRepository = recipesSavedRepository;
        }

        public async Task<List<RecipesSaved>> GetRecipesSaveByUserID(int userID)
        {
            return await _recipesSavedRepository.GetRecipesSaveByUserID(userID); 
        }
        public async Task SaveRecipeSaved(RecipesSaved recipesSaved)
        {
            await _recipesSavedRepository.SaveRecipeSaved(recipesSaved);
        }
    }
}

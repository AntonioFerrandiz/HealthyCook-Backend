using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RecipeRatingService : IRecipeRatingService
    {
        private readonly IRecipeRatingRepository _recipeRatingRepository;

        public RecipeRatingService(IRecipeRatingRepository recipeRatingRepository)
        {
            _recipeRatingRepository = recipeRatingRepository;
        }

        public async Task SaveRecipeRating(RecipeRating recipeRating)
        {
            await _recipeRatingRepository.SaveRecipeRating(recipeRating);
        }
    }
}

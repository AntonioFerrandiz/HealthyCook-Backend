using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IRecipeRatingService
    {

        Task SaveRecipeRating(RecipeRating recipeRating);
        Task<List<RecipeRating>> GetRatingByRecipe(int RecipeID);
        Task<int> GetAverageRatingOfRecipe(int RecipeID);
    }
}

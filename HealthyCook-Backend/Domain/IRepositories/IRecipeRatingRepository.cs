using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IRecipeRatingRepository
    {
        Task SaveRecipeRating(RecipeRating recipeRating);
        Task<List<RecipeRating>> GetRatingByRecipe(int RecipeID);
        Task<int> GetAverageRatingOfRecipe(int RecipeID);
    }
}

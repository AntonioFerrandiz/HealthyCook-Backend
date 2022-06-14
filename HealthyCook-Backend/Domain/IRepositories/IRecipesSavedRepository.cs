using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IRecipesSavedRepository
    {
        Task SaveRecipeSaved(RecipesSaved recipesSaved);
        Task RemoveRecipeSaved(RecipesSaved recipesSaved);
        Task<RecipesSaved> GetRecipeSaved(int recipeSavedID);
        Task<List<RecipesSaved>> GetRecipesSaveByUserID(int userID);
        Task<bool> VerifyRecipeSaved(int recipeID, int userID);
    }
}

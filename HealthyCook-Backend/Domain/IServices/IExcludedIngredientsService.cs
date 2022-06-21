using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IExcludedIngredientsService
    {
        Task AddExcludedIngredient(ExcludedIngredients excludedIngredients);
        Task RemoveExcludedIngredient(ExcludedIngredients excludedIngredients);
        Task<bool> VerifyExcludedIngredientSaved(string excludedIngredientName, int userID);
        Task<ExcludedIngredients> GetExcludedIngredient(int excludedIngredientID);
        Task<List<ExcludedIngredients>> GetExcludedIngredients(int userID);
    }
}

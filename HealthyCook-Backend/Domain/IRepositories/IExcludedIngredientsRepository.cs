using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IExcludedIngredientsRepository
    {
        Task AddExcludedIngredient(ExcludedIngredients excludedIngredients);
        Task RemoveExcludedIngredient(ExcludedIngredients excludedIngredients);
        Task<ExcludedIngredients> GetExcludedIngredient(int excludedIngredientID);
        Task<bool> VerifyExcludedIngredientSaved(string excludedIngredientName, int userID);
        Task<List<ExcludedIngredients>> GetExcludedIngredients(int userID);

    }
}

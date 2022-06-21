using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class ExcludedIngredientsService: IExcludedIngredientsService
    {
        private readonly IExcludedIngredientsRepository _excludedIngredientsRepository;
        public ExcludedIngredientsService(IExcludedIngredientsRepository excludedIngredientsRepository)
        {
            _excludedIngredientsRepository = excludedIngredientsRepository;
        }

        public async Task AddExcludedIngredient(ExcludedIngredients excludedIngredients)
        {
            await _excludedIngredientsRepository.AddExcludedIngredient(excludedIngredients);
        }

        public async Task<ExcludedIngredients> GetExcludedIngredient(int excludedIngredientID)
        {
            return await _excludedIngredientsRepository.GetExcludedIngredient(excludedIngredientID);
        }

        public async Task<List<ExcludedIngredients>> GetExcludedIngredients(int userID)
        {
            return await _excludedIngredientsRepository.GetExcludedIngredients(userID);
        }

        public async Task RemoveExcludedIngredient(ExcludedIngredients excludedIngredients)
        {
            await _excludedIngredientsRepository.RemoveExcludedIngredient(excludedIngredients);
        }

        public async Task<bool> VerifyExcludedIngredientSaved(string excludedIngredientName, int userID)
        {
            return await _excludedIngredientsRepository.VerifyExcludedIngredientSaved(excludedIngredientName, userID);
        }
    }
}

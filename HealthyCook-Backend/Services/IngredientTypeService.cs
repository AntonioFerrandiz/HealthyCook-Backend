using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class IngredientTypeService : IIngredientTypeService
    {
        private readonly IIngredientTypeRepository _ingredientTypeRepository;
        public IngredientTypeService(IIngredientTypeRepository ingredientTypeRepository)
        {
            _ingredientTypeRepository = ingredientTypeRepository;
        }

        public async Task SaveIngredientType(IngredientType ingredientType)
        {
            await _ingredientTypeRepository.SaveIngredientType(ingredientType);
        }
    }
}

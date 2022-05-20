using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IIngredientTypeRepository
    {
        Task SaveIngredientType(IngredientType ingredientType);
    }
}

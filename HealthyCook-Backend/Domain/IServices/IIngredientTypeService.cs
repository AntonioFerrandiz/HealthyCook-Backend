using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IIngredientTypeService
    {
        Task SaveIngredientType(IngredientType ingredientType);

    }
}

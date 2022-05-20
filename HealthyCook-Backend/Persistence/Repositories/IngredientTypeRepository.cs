using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Repositories
{
    public class IngredientTypeRepository : IIngredientTypeRepository
    {
        private readonly AplicationDbContext _context;
        public IngredientTypeRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveIngredientType(IngredientType ingredientType)
        {
            _context.Add(ingredientType);
            await _context.SaveChangesAsync();
        }
    }
}

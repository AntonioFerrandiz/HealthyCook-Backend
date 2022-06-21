using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Repositories
{
    public class ExcludedIngredientsRepository : IExcludedIngredientsRepository
    {
        private readonly AplicationDbContext _context;
        public ExcludedIngredientsRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddExcludedIngredient(ExcludedIngredients excludedIngredients)
        {
            _context.Add(excludedIngredients);
            await _context.SaveChangesAsync();
        }

        public async Task<ExcludedIngredients> GetExcludedIngredient(int excludedIngredientID)
        {
            var excludedIngredient = await _context.ExcludedIngredients
               .Where(x => x.ID == excludedIngredientID)
               .FirstOrDefaultAsync();
            return excludedIngredient;
        }

        public async Task<List<ExcludedIngredients>> GetExcludedIngredients(int userID)
        {
            var excludedIngredientsList = await _context.ExcludedIngredients
                .Where(x => x.UserID == userID)
                .ToListAsync();
            return excludedIngredientsList;
        }

        public async Task RemoveExcludedIngredient(ExcludedIngredients excludedIngredients)
        {
            _context.Entry(excludedIngredients).State = EntityState.Deleted;
            await _context.SaveChangesAsync ();
        }

        public async Task<bool> VerifyExcludedIngredientSaved(string excludedIngredientName, int userID)
        {
            var verifiy = await _context.ExcludedIngredients
                .AnyAsync(x => x.UserID == userID && x.IngredientName == excludedIngredientName);
            return verifiy;
        }
    }
}

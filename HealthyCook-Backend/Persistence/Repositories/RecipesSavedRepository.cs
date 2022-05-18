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
    public class RecipesSavedRepository : IRecipesSavedRepository
    {
        private readonly AplicationDbContext _context;

        public RecipesSavedRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RecipesSaved>> GetRecipesSaveByUserID(int userID)
        {
            var listRecipesSaved = await _context.RecipesSaveds
                .Where(x => x.UserID == userID)
                .ToListAsync();
            return listRecipesSaved;
        }
        public async Task SaveRecipeSaved(RecipesSaved recipesSaved)
        {
            _context.Add(recipesSaved);
            await _context.SaveChangesAsync();
        }
    }
}

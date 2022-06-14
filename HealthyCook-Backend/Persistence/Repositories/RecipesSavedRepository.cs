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

        public async Task<RecipesSaved> GetRecipeSaved(int recipeSavedID)
        {
            var recipeSaved = await _context.RecipesSaveds
                .Where(x => x.ID == recipeSavedID)
                .FirstOrDefaultAsync();
            return recipeSaved;
        }

        public async Task<List<RecipesSaved>> GetRecipesSaveByUserID(int userID)
        {
            var listRecipesSaved = await _context.RecipesSaveds
                .Where(x => x.UserID == userID)
                .ToListAsync();
            return listRecipesSaved;
        }

        public async Task RemoveRecipeSaved(RecipesSaved recipesSaved)
        {
            _context.Entry(recipesSaved).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task SaveRecipeSaved(RecipesSaved recipesSaved)
        {
            _context.Add(recipesSaved);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyRecipeSaved(int recipeID, int userID)
        {
            var verify = await _context.RecipesSaveds
                .AnyAsync(x => x.UserID == userID && x.RecipeSavedID == recipeID);
            return verify;
        }
    }
}

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
    public class RecipeDetailsRepository : IRecipeDetailsRepository
    {
        private readonly AplicationDbContext _context;
        public RecipeDetailsRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task SaveRecipeDetails(RecipeDetails recipeDetails)
        {
            _context.Add(recipeDetails);
            await _context.SaveChangesAsync();
        }
        public async Task<RecipeDetails> GetRecipeDetails(int recipeID)
        {
            var recipeDetails = await _context.RecipeDetails
                .Where(x => x.RecipeID == recipeID)
                .Include(x => x.ingredientTypes)
                .ThenInclude(x => x.ingredientsList)
                .FirstOrDefaultAsync();
            return recipeDetails;
        }

        public async Task<RecipeDetails> SearchRecipeDetails(int recipeID)
        {
            var recipe = await _context.RecipeDetails
                .Where(x => x.RecipeID == recipeID)
                .Include(x => x.ingredientTypes)
                .ThenInclude(x => x.ingredientsList)
                .FirstOrDefaultAsync();
            return recipe;
        }
    }
}

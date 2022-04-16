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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AplicationDbContext _context;
        public RecipeRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateRecipe(Recipe recipe)
        {
            _context.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetListRecipes()
        {
            var recipesList = await _context.Recipes
                .Where(x => x.Active == 1)
                .Select(o => new Recipe
            {
                ID = o.ID,
                Name = o.Name,
                Description = o.Description,
                User = new User { Username = o.User.Username }
                }).ToListAsync();

            return recipesList;
        }
    }
}

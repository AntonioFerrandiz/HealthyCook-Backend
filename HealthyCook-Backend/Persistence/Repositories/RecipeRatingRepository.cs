using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Repositories
{
    public class RecipeRatingRepository : IRecipeRatingRepository
    {
        private readonly AplicationDbContext _context;

        public RecipeRatingRepository(AplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveRecipeRating(RecipeRating recipeRating)
        {
            _context.Add(recipeRating);
            await _context.SaveChangesAsync();
        }
    }
}

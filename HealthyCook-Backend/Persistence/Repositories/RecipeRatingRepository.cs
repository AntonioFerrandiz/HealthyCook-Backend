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
    public class RecipeRatingRepository : IRecipeRatingRepository
    {
        private readonly AplicationDbContext _context;

        public RecipeRatingRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetAverageRatingOfRecipe(int RecipeID)
        {
            var listRating = await GetRatingByRecipe(RecipeID);
            
            var count = listRating.Count;
            if (count == 0) return 0;
            var total = 0;

            foreach(var rating in listRating)
            {
                total += rating.Rating;
            }

            var avg = total / count;

            return avg;
        }

        public async Task<List<RecipeRating>> GetRatingByRecipe(int RecipeID)
        {
            var listRating = await _context.RecipeRatings
                .Where(x => x.RecipeID == RecipeID)
                .ToListAsync();
            return listRating;
        }

        public async Task SaveRecipeRating(RecipeRating recipeRating)
        {
            _context.Add(recipeRating);
            await _context.SaveChangesAsync();
        }
    }
}

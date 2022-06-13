using HealthyCook_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }
        public DbSet<RecipeDetails> RecipeDetails { get; set; }
        public DbSet<RecipesSaved> RecipesSaveds { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<ExcludedIngredients> ExcludedIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {}
    }
}

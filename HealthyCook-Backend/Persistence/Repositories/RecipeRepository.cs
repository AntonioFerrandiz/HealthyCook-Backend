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

        public async Task<int> GetNumberOfRecipes()
        {
            var numberOfRecipes = await _context.Recipes
                .Where(x => x.Active == 1 && x.Published == 1)
                .CountAsync();
            return numberOfRecipes;
        }
        public async Task<List<Recipe>> GetLastFiveRecipes()
        {
            var recipesList = await _context.Recipes
                .FromSqlRaw("select top 5  r.ID, r.Name, r.Description, r.Preparation, r.Active, r.Published, r.UserID, r.DateCreated, rd.PreparationTime, rd.TimePeriod, rd.Servings, rd.Difficulty, rd.Calories " +
                "from [dbo].[RecipeDetails] as rd left outer join [dbo].[Recipes] as r on rd.RecipeID = r.ID where r.Published = 1 and r.Active = 1 order by r.ID desc")
                .ToListAsync();
            return recipesList;
        }
        public async Task<List<Recipe>> SearchRecipeByIngredient(string ingredient, string excludedIngredient)
        {
            
            //var recipeList = await _context.Recipes
            //    .FromSqlRaw("select r.ID, r.Name, r.Description, r.Preparation, r.Active, r.Published, r.UserID, r.DateCreated " +
            //            $"from [dbo].[Ingredients] as i join [dbo].[IngredientTypes] as it on i.IngredientTypeID = it.ID join [dbo].[RecipeDetails] as rd on it.RecipeDetailsID = rd.ID join [dbo].[Recipes] as r on rd.RecipeID = r.ID where i.Name = '{ingredient}'")
            //    .ToListAsync();
            //return recipeList;
            var recipeList = await _context.Recipes
                .FromSqlRaw("select r.ID, r.Name, r.Description, r.Preparation, r.Active, r.Published, r.UserID, r.DateCreated " +
                        $"from [dbo].[Ingredients] as i join [dbo].[IngredientTypes] as it on i.IngredientTypeID = it.ID join [dbo].[RecipeDetails] as rd on it.RecipeDetailsID = rd.ID join [dbo].[Recipes] as r on rd.RecipeID = r.ID where i.Name = '{ingredient}' " +
                        "EXCEPT " +
                        "select r.ID, r.Name, r.Description, r.Preparation, r.Active, r.Published, r.UserID, r.DateCreated " +
                        $"from [dbo].[Ingredients] as i join [dbo].[IngredientTypes] as it on i.IngredientTypeID = it.ID join [dbo].[RecipeDetails] as rd on it.RecipeDetailsID = rd.ID join [dbo].[Recipes] as r on rd.RecipeID = r.ID where i.Name = '{excludedIngredient}' ")
                .ToListAsync();
            return recipeList;
        }
        public async Task<List<Recipe>> GetListRecipes()
        {
            var recipesList = await _context.Recipes
                .Where(x => x.Active == 1 && x.Published == 1)
                .Select(o => new Recipe
            {
                ID = o.ID,
                Name = o.Name,
                Description = o.Description,
                Preparation = o.Preparation,
                User = new User { Username = o.User.Username },
                }).ToListAsync();

            return recipesList;
        }

        public async Task<Recipe> ChangePublicationStatus(int recipeID)
        {
            //var recipe = await _context.Recipes.FromSqlRaw("SELECT * FROM dbo.Recipes")
            //    .FirstOrDefaultAsync();

            var recipe = await _context.Recipes.FirstOrDefaultAsync(x => x.ID == recipeID);
            if(recipe != null)
            {
                if (recipe.Published == 1)
                {
                    recipe.Published = 0;
                }else
                {
                    recipe.Published = 1;
                }
                
            }
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> GetRecipeByID(int recipeID)
        {
            var id = recipeID;
            var recipe = await _context.Recipes
                .Where(x => x.ID == recipeID)
                .Select(o => new Recipe
                {
                    ID = o.ID,
                    Name = o.Name,
                    Description = o.Description,
                    Preparation = o.Preparation,
                    User = new User { Username = o.User.Username },
                })
                .FirstOrDefaultAsync();
            return recipe;
        }

        public async Task<List<Recipe>> GetListRecipesPublishedByUser(int userID)
        {
            var recipeList = await _context.Recipes
                .Where(x => x.UserID == userID && x.Published == 1)
                .ToListAsync();
            return recipeList;
        }

        public async Task<List<Recipe>> GetListRecipesNoPublishedByUser(int userID)
        {
            var recipeList = await _context.Recipes
                .Where(x => x.UserID == userID && x.Published == 0)
                .ToListAsync();
            return recipeList;
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetTodaysRecipes(string date)
        {
            var todayDate = DateTime.Now.ToString("dd-MM-yyyy");
            var recipeList = await _context.Recipes
                .Where(x => x.Published == 1 && x.Active == 1 && x.DateCreated == todayDate)
                .ToListAsync();
            return recipeList;
        }
    }
}

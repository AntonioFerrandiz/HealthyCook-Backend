﻿using HealthyCook_Backend.Domain.IRepositories;
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
    }
}

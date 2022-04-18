﻿using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IRecipeService
    {
        Task CreateRecipe(Recipe recipe);
        Task<Recipe> GetRecipeByID(int recipeID);
        Task<Recipe> ChangePublicationStatus(int recipeID);
        Task<List<Recipe>> GetListRecipes();
        Task<List<Recipe>> GetListRecipesPublishedByUser(int userID);
        Task<List<Recipe>> GetListRecipesNoPublishedByUser(int userID);
    }
}

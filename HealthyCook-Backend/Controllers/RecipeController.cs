using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Recipe recipe)
        {
            try
            {
                recipe.UserID = 1;
                recipe.Active = 1;
                
                await _recipeService.CreateRecipe(recipe);
                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{recipeID}")]
        public async Task<IActionResult> GetRecipeByID(int recipeID)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeByID(recipeID);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListRecipes")]
        [HttpGet]
        public async Task<IActionResult> GetListRecipes()
        {
            try
            {
                var recipeList = await _recipeService.GetListRecipes();
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListRecipesPublishedByUser/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetListRecipesPublishedByUser(int userId)
        {
            try
            {
                var recipeList = await _recipeService.GetListRecipesPublishedByUser(1);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListRecipesNoPublishedByUser/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetListRecipesNoPublishedByUser(int userId)
        {
            try
            {
                var recipeList = await _recipeService.GetListRecipesNoPublishedByUser(1);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("ChangePublicationStatus/{recipeID}")]
        [HttpPut]
        public async Task<IActionResult> ChangePublicationStatus(int recipeID)
        {
            try
            {
                var recipe = await _recipeService.ChangePublicationStatus(recipeID);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        
    }
}

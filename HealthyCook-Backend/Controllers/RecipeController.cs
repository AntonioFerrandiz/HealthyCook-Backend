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

        /// <summary>
        /// Registro de receta
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Recipe recipe)
        {
            try
            {
                recipe.UserID = 1;
                recipe.Active = 1;
                recipe.Published = 0;
                await _recipeService.CreateRecipe(recipe);
                return Ok(new { message = recipe.ID });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Eliminación de receta
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        [HttpDelete("{recipeID}")]
        public async Task<IActionResult> DeleteRecipe(int recipeID)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeByID(recipeID);
                if (recipe == null) return BadRequest(new { message = "no se encontro la receta" });
                await _recipeService.DeleteRecipe(recipe);
                return Ok(new { message = "se elimino xd" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener receta por ID
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
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

        [Route("GetTodaysRecipes/{date}")]
        [HttpGet]
        public async Task<IActionResult> GetTodaysRecipes(string date)
        {
            try
            {
                var recipeList = await _recipeService.GetTodaysRecipes(date);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetLastFiveRecipes")]
        [HttpGet]
        public async Task<IActionResult> GetLastFiveRecipes()
        {
            try
            {
                var recipeList = await _recipeService.GetLastFiveRecipes();
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener el número de la cantidad de recetas publicadas
        /// </summary>
        /// <returns></returns>
        [Route("GetNumberOfRecipes")]
        [HttpGet]
        public async Task<int> GetNumberOfRecipes()
        {
            var numberOfRecipes = await _recipeService.GetNumberOfRecipes();
            return numberOfRecipes;
        }

        /// <summary>
        /// Obtener lista de todas las recetas disponibles
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Obtener lista de las recetas publicadas por usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtener lista de las recetas que aun no han sido publicas por usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Realizar uns busqueda de recetas a base de uno o más ingredientes ingresados, así mismo se tendrá en cuenta los ingredientes excluidos al momento de realizar la búsqueda
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="excludedIngredient"></param>
        /// <returns></returns>
        [Route("SearchRecipeByIngredient/{ingredient}/{excludedIngredient?}")]
        [HttpGet]
        public async Task<IActionResult> SearchRecipeByIngredient(string ingredient, string excludedIngredient)

        {
            if (ingredient == excludedIngredient)
            {
                return BadRequest("No puedes buscar una receta con un ingrediente que has agregado a la lista de ingredientes excluidos");
            }
            try
            {
                var recipeList = await _recipeService.SearchRecipeByIngredient(ingredient, excludedIngredient);
                return Ok(recipeList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cambiar estado de publicación de la receta
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
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

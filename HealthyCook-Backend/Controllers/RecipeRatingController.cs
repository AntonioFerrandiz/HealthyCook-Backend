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
    public class RecipeRatingController : ControllerBase
    {
        private readonly IRecipeRatingService _recipeRatingService;

        public RecipeRatingController(IRecipeRatingService recipeRatingService)
        {
            _recipeRatingService = recipeRatingService;
        }

        /// <summary>
        /// Guardar califación de receta
        /// </summary>
        /// <param name="recipeRating"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RecipeRating recipeRating)
        {
            try
            {
                await _recipeRatingService.SaveRecipeRating(recipeRating);
                return Ok(new { message = "Califación exitosa" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener todas las puntuaciones hechas hacia una receta
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        [Route("GetRatingByRecipe/{RecipeID}")]
        [HttpGet]
        public async Task<IActionResult> GetRatingByRecipe(int RecipeID)
        {
            try
            {
                var ratingList = await _recipeRatingService.GetRatingByRecipe(RecipeID);
                return Ok(ratingList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener el promedio de rating de una receta por recipeID
        /// </summary>
        /// <param name="RecipeID"></param>
        /// <returns></returns>
        [Route("GetAverageRatingOfRecipe/{RecipeID}")]
        [HttpGet]
        public async Task<int> GetAverageRatingOfRecipe(int RecipeID)
        {
            try
            {
                var ratingAvg = await _recipeRatingService.GetAverageRatingOfRecipe(RecipeID);
                return ratingAvg;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

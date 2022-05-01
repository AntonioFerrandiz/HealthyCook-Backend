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
    }
}

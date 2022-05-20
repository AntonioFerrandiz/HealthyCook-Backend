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
    public class RecipeDetailsController : ControllerBase
    {
        private readonly IRecipeDetailsService _recipeDetailsService;

        public RecipeDetailsController(IRecipeDetailsService recipeDetailsService)
        {
            _recipeDetailsService = recipeDetailsService;
        }


        /// <summary>
        /// Registro de los detalles de la receta
        /// </summary>
        /// <param name="recipeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RecipeDetails recipeDetails)
        {
            try
            {
                await _recipeDetailsService.SaveRecipeDetails(recipeDetails);
                return Ok(recipeDetails);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener detalles de la receta por la ID de la receta
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [Route("GetRecipeDetails/{recipeId}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeDetails(int recipeId)
        {
            try
            {
                var recipeDetail = await _recipeDetailsService.GetRecipeDetails(recipeId);
                return Ok(recipeDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Busqueda de los detalles de la receta por la ID de la receta
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [Route("SearchRecipeDetails/{recipeId}")]
        [HttpGet]
        public async Task<IActionResult> SearchRecipeDetails(int recipeId)
        {
            try
            {
                var recipeDetail = await _recipeDetailsService.SearchRecipeDetails(recipeId);
                return Ok(recipeDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RecipeDetails recipeDetails)
        {
            try
            {
                recipeDetails.DateCreated = DateTime.Now;
                await _recipeDetailsService.SaveRecipeDetails(recipeDetails);
                return Ok(new { message = "ok recipe details" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
    }
}

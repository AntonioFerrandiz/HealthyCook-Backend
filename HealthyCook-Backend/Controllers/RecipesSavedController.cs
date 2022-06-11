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
    public class RecipesSavedController : ControllerBase
    {
        private readonly IRecipesSavedService _recipesSavedService;


        public RecipesSavedController(IRecipesSavedService recipesSavedService)
        {
            _recipesSavedService = recipesSavedService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecipesSaved recipesSaved)
        {
            try
            {
                recipesSaved.UserID = 1;
                await _recipesSavedService.SaveRecipeSaved(recipesSaved);
                return Ok(new { message = "Receta guardada exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("GetRecipesSavedByUserID/{userID}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipesSavedByUserID(int userID)
        {
            try
            {
                var recipesSavedList = await _recipesSavedService.GetRecipesSaveByUserID(userID);
                return Ok(recipesSavedList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("VerifyRecipeSaved/{recipeID}/{userID}")]
        [HttpGet]
        public async Task<bool> VerifyRecipeSaved(int recipeID, int userID)
        {
            var verify = await _recipesSavedService.VerifyRecipeSaved(recipeID, 1);
            return verify;
        }

    }
}

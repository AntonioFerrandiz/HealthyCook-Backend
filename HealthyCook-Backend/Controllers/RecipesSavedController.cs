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

        /// <summary>
        /// Agregar receta a lista de recetas de recetas guardadas
        /// </summary>
        /// <param name="recipesSaved"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Obtener recetas guardadas mediante la id del usuario
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para verificar si un usuario ya guardó con anteriodidad una receta
        /// </summary>
        /// <param name="recipeID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("VerifyRecipeSaved/{recipeID}/{userID}")]
        [HttpGet]
        public async Task<bool> VerifyRecipeSaved(int recipeID, int userID)
        {
            var verify = await _recipesSavedService.VerifyRecipeSaved(recipeID, 1);
            return verify;
        }

        [HttpDelete("{recipeSavedID}")]
        public async Task<IActionResult> DeleteRecipeSaved(int recipeSavedID)
        {
            try
            {
                var recipeSaved = await _recipesSavedService.GetRecipeSaved(recipeSavedID);
                await _recipesSavedService.RemoveRecipeSaved(recipeSaved);
                return Ok(new { message = "Se eliminó con exito la receta guardada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

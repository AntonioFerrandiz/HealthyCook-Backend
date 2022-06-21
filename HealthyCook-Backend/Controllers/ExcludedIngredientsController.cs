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
    public class ExcludedIngredientsController : ControllerBase
    {
        private readonly IExcludedIngredientsService _excludedIngredientsService;
        public ExcludedIngredientsController(IExcludedIngredientsService excludedIngredientsService)
        {
            _excludedIngredientsService = excludedIngredientsService;
        }

        /// <summary>
        /// Agregar un nuevo ingrediente a la lista de ingredientes excluidos
        /// </summary>
        /// <param name="excludedIngredients"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExcludedIngredients excludedIngredients)
        {
            try
            {
                excludedIngredients.UserID = 1;
                var verify = await _excludedIngredientsService.VerifyExcludedIngredientSaved(excludedIngredients.IngredientName, 1);
                if (!verify)
                {
                    await _excludedIngredientsService.AddExcludedIngredient(excludedIngredients);
                    return Ok();
                }
                return BadRequest("Ya agregaste este ingrediente a tu lista");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener todos los ingredientes excluidos por el usuario
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("GetListExcludedIngredientsByUser/{userID}")]
        [HttpGet]
        public async Task<IActionResult> GetListExcludedIngredientsByUser(int userID)
        {
            try
            {
                var excludedIngredientList = await _excludedIngredientsService.GetExcludedIngredients(userID);
                return Ok(excludedIngredientList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SearchExcludedIngredient/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetListExcludedIngredients(int id)
        {
            try
            {
                var excludedIngredientList = await _excludedIngredientsService.GetExcludedIngredient(id);
                return Ok(excludedIngredientList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Remover un ingrediente excluido de la lista
        /// </summary>
        /// <param name="excludedIngredientID"></param>
        /// <returns></returns>
        [HttpDelete("{excludedIngredientID}")]
        public async Task<IActionResult> RemoveExcludedIngredient(int excludedIngredientID)
        {
            try
            {
                var excludedIngredient = await _excludedIngredientsService.GetExcludedIngredient(excludedIngredientID);
                await _excludedIngredientsService.RemoveExcludedIngredient(excludedIngredient);
                return Ok(new { message = $"{excludedIngredient.IngredientName} eliminado de la lista correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

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
    public class IngredientTypeController : ControllerBase
    {
        private readonly IIngredientTypeService _ingredientTypeService;
        public IngredientTypeController(IIngredientTypeService ingredientTypeService)
        {
            _ingredientTypeService = ingredientTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IngredientType ingredientType)
        {
            try
            {
                await _ingredientTypeService.SaveIngredientType(ingredientType);
                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

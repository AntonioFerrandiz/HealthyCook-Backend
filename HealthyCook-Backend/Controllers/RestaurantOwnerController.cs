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
    public class RestaurantOwnerController : ControllerBase
    {
        private readonly IRestaurantOwnerService _restaurantOwnerService;

        public RestaurantOwnerController(IRestaurantOwnerService restaurantOwnerService)
        {
            _restaurantOwnerService = restaurantOwnerService;
        }
        
        /// <summary>
        /// Registro de dueño de restaurante 
        /// </summary>
        /// <param name="restaurantOwner"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestaurantOwner restaurantOwner)
        {
            try
            {
                await _restaurantOwnerService.SaveRestaurantOwner(restaurantOwner);
                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Buscar dueño de restaurante por ID
        /// </summary>
        /// <param name="restaurantOwnerID"></param>
        /// <returns></returns>
        [HttpGet("{restaurantOwnerID}")]
        public async Task<IActionResult> GetRestaurantOwner(int restaurantOwnerID)
        {
            try
            {
                var restaurantOwner = await _restaurantOwnerService.GetRestaurantOwner(restaurantOwnerID);
                return Ok(restaurantOwner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}

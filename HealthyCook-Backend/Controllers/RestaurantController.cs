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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Registro de resturante
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
        {
            try
            {
                await _restaurantService.CreateRestaurant(restaurant);
                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminación de restaurante
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        [HttpDelete("{restaurantID}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantID)
        {
            try
            {
                var restaurant = await _restaurantService.SearchRestaurant(restaurantID);
                if (restaurant == null) return BadRequest(new { message = "no se encontro el restaurante" });
                await _restaurantService.DeleteRestaurant(restaurant);
                return Ok(new { message = "se elimino xd" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener restaurante por ID
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        [HttpGet("{restaurantID}")]
        public async Task<IActionResult> GetRestaurant(int restaurantID)
        {
            try
            {
                var restaurant = await _restaurantService.SearchRestaurant(restaurantID);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busqueda de restaurante por ID
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        [Route("SearchRestaurant/{restaurantID}")]
        [HttpGet]
        public async Task<IActionResult> SearchRestaurant(int restaurantID)
        {
            try
            {
                var restaurant = await _restaurantService.SearchRestaurant(restaurantID);
                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener lista de todos los restaurantes
        /// </summary>
        /// <returns></returns>
        [Route("GetListRestaurants")]
        [HttpGet]
        public async Task<IActionResult> GetListRestaurants()
        {
            try
            {
                var restaurantList = await _restaurantService.GetListRestaurants();
                return Ok(restaurantList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

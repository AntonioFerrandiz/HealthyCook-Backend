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
    public class RestaurantReviewController : ControllerBase
    {
        private readonly IRestaurantReviewService _restaurantReviewService;
        public RestaurantReviewController(IRestaurantReviewService restaurantReviewService)
        {
            _restaurantReviewService = restaurantReviewService;
        }

        /// <summary>
        /// Publicación de reseña hacia un restaurante
        /// </summary>
        /// <param name="restaurantReview"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestaurantReview restaurantReview)
        {
            try
            {
                await _restaurantReviewService.CreateRestaurantReview(restaurantReview);
                return Ok(new { message = "ok" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminación de reseña
        /// </summary>
        /// <param name="restaurantReviewID"></param>
        /// <returns></returns>
        [HttpDelete("{restaurantReviewID}")]
        public async Task<IActionResult> DeleteRestaurantReview(int restaurantReviewID)
        {
            try
            {
                var restaurantReview = await _restaurantReviewService.GetRestaurantReview(restaurantReviewID);
                if (restaurantReview == null) return BadRequest(new { message = "no se encontro la reseña" });
                await _restaurantReviewService.DeleteRestaurantReview(restaurantReview);
                return Ok(new { message = "se elimino xd" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Buscar reseña por ID
        /// </summary>
        /// <param name="restaurantReviewID"></param>
        /// <returns></returns>
        [HttpGet("{restaurantReviewID}")]
        public async Task<IActionResult> GetRestaurantReview(int restaurantReviewID)
        {
            try
            {
                var restaurantReview = await _restaurantReviewService.GetRestaurantReview(restaurantReviewID);
                return Ok(restaurantReview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener lista de reseñas hechas a un restaurante
        /// </summary>
        /// <param name="restaurantID"></param>
        /// <returns></returns>
        [Route("GetRestaurantReviewList/{restaurantID}")]
        [HttpGet]
        public async Task<IActionResult> GetRestaurantReviewList(int restaurantID)
        {
            try
            {
                var restaurantReviewList = await _restaurantReviewService.GetRestaurantReviewList(restaurantID);
                return Ok(restaurantReviewList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Buscar reseñas por calificación
        /// </summary>
        /// <param name="calification"></param>
        /// <returns></returns>
        [Route("SearchRestaurantReviewByCalification/{calification}")]
        [HttpGet]
        public async Task<IActionResult> SearchRestaurantReviewByCalification(int calification)
        {
            try
            {
                var restaurantReviewList = await _restaurantReviewService.SearchRestaurantReviewByCalification(calification);
                return Ok(restaurantReviewList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

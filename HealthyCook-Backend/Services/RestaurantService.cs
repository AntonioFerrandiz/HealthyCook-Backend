using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RestaurantService : IRestaurantService
    {
        public readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.CreateRestaurant(restaurant);
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            await _restaurantRepository.DeleteRestaurant(restaurant);
        }

        public async Task<List<Restaurant>> GetListRestaurants()
        {
            return await _restaurantRepository.GetListRestaurants();
        }

        public async Task<Restaurant> SearchRestaurant(int restaurantID)
        {
            return await _restaurantRepository.SearchRestaurant(restaurantID);
        }
    }
}

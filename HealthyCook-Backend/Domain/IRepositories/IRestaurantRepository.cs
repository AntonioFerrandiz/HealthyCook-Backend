using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IRestaurantRepository
    {
        Task CreateRestaurant(Restaurant restaurant);

        Task DeleteRestaurant(Restaurant restaurant);
        Task<Restaurant> SearchRestaurant(int restaurantID);
        Task<List<Restaurant>> GetListRestaurants();

    }
}

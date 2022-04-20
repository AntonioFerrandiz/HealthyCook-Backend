using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RestaurantOwnerService: IRestaurantOwnerService
    {
        private readonly IRestaurantOwnerRepository _restaurantOwnerRepository;

        public RestaurantOwnerService(IRestaurantOwnerRepository restaurantOwnerRepository)
        {
            _restaurantOwnerRepository = restaurantOwnerRepository;
        }

        public async Task SaveRestaurantOwner(RestaurantOwner restaurantOwner)
        {
            await _restaurantOwnerRepository.SaveRestaurantOwner(restaurantOwner);
        }
        public async Task<RestaurantOwner> GetRestaurantOwner(int restaurantOwnerID)
        {
            return await _restaurantOwnerRepository.GetRestaurantOwner(restaurantOwnerID);
        }
    }
}

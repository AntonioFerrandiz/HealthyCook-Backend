using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IRepositories
{
    public interface IRestaurantOwnerRepository
    {
        Task SaveRestaurantOwner(RestaurantOwner restaurantOwner);

        Task<RestaurantOwner> GetRestaurantOwner(int restaurantOwnerID);
    }
}

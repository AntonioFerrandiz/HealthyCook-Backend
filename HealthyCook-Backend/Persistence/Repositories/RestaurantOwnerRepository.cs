using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Persistence.Repositories
{
    public class RestaurantOwnerRepository : IRestaurantOwnerRepository
    {
        private readonly AplicationDbContext _context;
        public RestaurantOwnerRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task SaveRestaurantOwner(RestaurantOwner restaurantOwner)
        {
            _context.Add(restaurantOwner);
            await _context.SaveChangesAsync();
        }
        public async Task<RestaurantOwner> GetRestaurantOwner(int restaurantOwnerID)
        {
            var restaurantOwner = await _context.RestaurantOwners
                .Where(x => x.ID == restaurantOwnerID)
                .FirstOrDefaultAsync();
            return restaurantOwner;
        }
    }
}

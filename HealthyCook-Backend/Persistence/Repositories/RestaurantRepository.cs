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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AplicationDbContext _context;

        public RestaurantRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            _context.Add(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Restaurant>> GetListRestaurants()
        {
            var restaurantList = await _context.Restaurants
                .Where(x => x.Active == 1)
                .Select(r => new Restaurant
                {
                    ID = r.ID,
                    Name = r.Name,
                    Description = r.Description,
                    BusinessType = r.BusinessType,
                    ContactNumber = r.ContactNumber,
                    ContactEmail = r.ContactEmail,
                    Address = r.Address,
                    RestaurantOwner = new RestaurantOwner
                    {
                        ID = r.RestaurantOwner.ID,
                        Firstname = r.RestaurantOwner.Firstname,
                        Lastname = r.RestaurantOwner.Lastname
                    }
                })
                .ToListAsync();
            return restaurantList;
        }

        public async Task<Restaurant> SearchRestaurant(int restaurantID)
        {
            var restaurant = await _context.Restaurants
                .Where(x => x.ID == restaurantID && x.Active == 1)
                .Select(r => new Restaurant
                {
                    ID = r.ID,
                    Active = r.Active,
                    Name = r.Name,
                    Description = r.Description,
                    BusinessType = r.BusinessType,
                    ContactNumber = r.ContactNumber,
                    ContactEmail = r.ContactEmail,
                    Address = r.Address,
                    RestaurantOwner = new RestaurantOwner
                    {
                        ID = r.RestaurantOwner.ID,
                        Firstname = r.RestaurantOwner.Firstname,
                        Lastname = r.RestaurantOwner.Lastname
                    }
                })
                .FirstOrDefaultAsync();
            return restaurant;
        }
    }
}

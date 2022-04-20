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
    public class RestaurantReviewRepository : IRestaurantReviewRepository
    {
        private readonly AplicationDbContext _context;
        public RestaurantReviewRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurantReview(RestaurantReview restaurantReview)
        {
            _context.Add(restaurantReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantReview(RestaurantReview restaurantReview)
        {
            _context.Entry(restaurantReview).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RestaurantReview> GetRestaurantReview(int restaurantReviewID)
        {
            var restaurantReview = await _context.RestaurantReviews
                .Where(x => x.ID == restaurantReviewID)
                .FirstOrDefaultAsync();
            return restaurantReview;
        }

        public async Task<List<RestaurantReview>> GetRestaurantReviewList(int restaurantID)
        {
            var restaurantReviewList = await _context.RestaurantReviews
                .Where(x => x.RestaurantID == restaurantID)
                .ToListAsync();
            return restaurantReviewList;
        }

        public async Task<List<RestaurantReview>> SearchRestaurantReviewByCalification(int calification)
        {
            var restaurantReviewList = await _context.RestaurantReviews
                .Where(x => x.Calification == calification)
                .ToListAsync();
            return restaurantReviewList;
        }
    }
}

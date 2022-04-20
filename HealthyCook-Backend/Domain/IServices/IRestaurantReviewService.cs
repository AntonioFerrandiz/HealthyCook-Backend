using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Domain.IServices
{
    public interface IRestaurantReviewService
    {
        Task CreateRestaurantReview(RestaurantReview restaurantReview);
        Task DeleteRestaurantReview(RestaurantReview restaurantReview);
        Task<RestaurantReview> GetRestaurantReview(int restaurantReviewID);
        Task<List<RestaurantReview>> GetRestaurantReviewList(int restaurantID);
        Task<List<RestaurantReview>> SearchRestaurantReviewByCalification(int calification);
    }
}

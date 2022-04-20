using HealthyCook_Backend.Domain.IRepositories;
using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Services
{
    public class RestaurantReviewService : IRestaurantReviewService
    {
        public readonly IRestaurantReviewRepository _restaurantReviewRepository;
        public RestaurantReviewService(IRestaurantReviewRepository restaurantReviewRepository)
        {
            _restaurantReviewRepository = restaurantReviewRepository;
        }
        public async Task CreateRestaurantReview(RestaurantReview restaurantReview)
        {
            await _restaurantReviewRepository.CreateRestaurantReview(restaurantReview);
        }

        public async Task DeleteRestaurantReview(RestaurantReview restaurantReview)
        {
            await _restaurantReviewRepository.DeleteRestaurantReview(restaurantReview);
        }

        public async Task<RestaurantReview> GetRestaurantReview(int restauranReviewtID)
        {
            return await _restaurantReviewRepository.GetRestaurantReview(restauranReviewtID);
        }

        public async Task<List<RestaurantReview>> GetRestaurantReviewList(int restaurantID)
        {
            return await _restaurantReviewRepository.GetRestaurantReviewList(restaurantID);
        }

        public async Task<List<RestaurantReview>> SearchRestaurantReviewByCalification(int calification)
        {
            return await _restaurantReviewRepository.SearchRestaurantReviewByCalification(calification);
        }
    }
}

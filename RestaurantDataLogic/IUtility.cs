using System.Collections.Generic;

namespace RestaurantDataLogic
{
    public interface IUtility
    {
        // Restaurant utilities
        int AddRestaurant(Restaurant r);
        void EditRestaurant(Restaurant r, int restaurantId);
        void DeleteRestaurant(int id);

        // Review utilities
        void AddReview(Review r);
        void EditReview(Review r, int reviewId);
        void DeleteReview(int id);

        // Get model lists
        int GetRestaurantId(string restaurantName);
        List<Restaurant> GetRestaurantModels();
        List<Review> GetReviewModels();
        List<Review> GetReviewModels(int restaurantId);
    }
}

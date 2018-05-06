using System.Collections.Generic;

namespace RestaurantDataLogic
{
    /// <summary>
    /// Class used for dependency injection for storage
    /// Database, xml, etc.
    /// </summary>
    public class Storage
    {
        private IUtility utility;
        public Storage(IUtility utility)
        {
            this.utility = utility;
        }
        public int AddRestaurant(Restaurant r) { return utility.AddRestaurant(r); }
        public void EditRestaurant(Restaurant r, int restaurantId) { utility.EditRestaurant(r, restaurantId); }
        public void DeleteRestaurant(int id) { utility.DeleteRestaurant(id); }

        public void AddReview(Review r) { utility.AddReview(r); }
        public void EditReview(Review r, int reviewId) { utility.EditReview(r, reviewId); }
        public void DeleteReview(int id) { utility.DeleteReview(id); }

        public int GetRestaurantId(string restaurantName) { return utility.GetRestaurantId(restaurantName); }
        public List<Restaurant> GetRestaurantModels() { return utility.GetRestaurantModels(); }
        public List<Review> GetReviewModels(int restaurantId) { return utility.GetReviewModels(restaurantId); }
    }
}

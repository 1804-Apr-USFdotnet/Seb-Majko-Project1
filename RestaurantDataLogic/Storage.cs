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
        public int GetRestaurantId(string restaurantName) { return utility.GetRestaurantId(restaurantName); }
        public List<Restaurant> GetRestaurantModels() { return utility.GetRestaurantModels(); }
        public List<Review> GetReviewModels(int restaurantId) { return utility.GetReviewModels(restaurantId); }
    }
}

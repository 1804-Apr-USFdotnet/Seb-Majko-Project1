using System.Collections.Generic;
using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    /// <summary>
    /// Convert entity models to output objects
    /// </summary>
    static internal class ConvertModels
    {
        //convert list of restaurants to list of restaurantInfo
        static internal List<RestaurantInfo> GetRestaurantInfos(List<Restaurant> restaurants)
        {
            List<RestaurantInfo> output = new List<RestaurantInfo>();
            foreach (var restaurant in restaurants)
            {
                output.Add((RestaurantInfo)restaurant);
            }
            return output;
        }

        //convert list of reviews to list of reviewInfo
        static internal List<ReviewInfo> GetReviewInfos(List<Review> reviews)
        {
            List<ReviewInfo> output = new List<ReviewInfo>();
            foreach (var review in reviews)
            {
                output.Add((ReviewInfo)review);
            }
            return output;
        }
    }
}

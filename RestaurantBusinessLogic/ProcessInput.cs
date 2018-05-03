using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    public static class ProcessInput
    {
        static public List<RestaurantInfo> GetRestaurants(params string[] restaurantParams)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            List<RestaurantInfo> restaurantsInfo = new List<RestaurantInfo>();
            //string response = null;

            // 1) Validate input
            ValidateInput.Validate(restaurantParams);

            // 2) Dependency injection for entity storage
            Storage storage = new Storage(new DBUtility());

            // 3) Get list of restaurants from database
            restaurants = storage.GetRestaurantModels();

            // 4) Convert list of restaurant models to list of restaurant output objects
            restaurantsInfo = ConvertModels.GetRestaurantInfos(restaurants);

            // 5) Sort list based on optional parameters
            if (restaurantParams.Length > 1) { SortRestaurants.Sort(ref restaurantsInfo, restaurantParams); }

            // 6) Create response json string
            // response = JsonConvert.SerializeObject(restaurantsInfo);

            // 7) Return response to client
            return restaurantsInfo;
        }

        static public string GetReviews(params string[] reviewParams)
        {
            List<Review> reviews = new List<Review>();
            List<ReviewInfo> reviewsInfo = new List<ReviewInfo>();
            string response = null;

            // 1) Validate input
            ValidateInput.Validate(reviewParams);

            // 2) Dependency injection
            Storage storage = new Storage(new DBUtility());

            // 3) Get restaurant id based on name
            int restaurantId = storage.GetRestaurantId(string.Join(" ", reviewParams.Skip(1).ToArray()));

            // 4) Get list of reviews from database based on restaurant id
            reviews = storage.GetReviewModels(restaurantId);

            // 5) Convert list of review models to list of review output objects
            reviewsInfo = ConvertModels.GetReviewInfos(reviews);

            // 6) Create response json string
            response = JsonConvert.SerializeObject(reviewsInfo);

            // 7) Return response to client
            return response;
        }

        //public static  Response(params string[] inputParams)
        //{
        //    if (inputParams[0] == "restaurants") return GetRestaurants(inputParams);
        //    if (inputParams[0] == "reviews") return GetReviews(inputParams);

        //    return null;
        //}
    }
}

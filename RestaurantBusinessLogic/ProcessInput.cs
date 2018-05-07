using System;
using System.Collections.Generic;
using System.Data.Common;
using NLog;
using RestaurantBusinessLogic.CustomExceptions;
using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    public static class ProcessInput
    {
        static private Logger logger = LogManager.GetCurrentClassLogger();

        static public List<RestaurantInfo> GetRestaurants(params string[] restaurantParams)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            List<RestaurantInfo> restaurantsInfo = new List<RestaurantInfo>();

            try
            {
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
            }
            catch (InvalidParameterException e) { logger.Error(e.Message); }
            catch (InvalidCommandException e) { logger.Error(e.Message); }
            catch (InvalidInputException e) { logger.Error(e.Message); }
            catch (DbException e) { logger.Error(e.Message); }
            catch (Exception e) { logger.Error(e.Message); }

            // 7) Return response to client
            return restaurantsInfo;
        }

        static public List<ReviewInfo> GetReviews(int id)
        {
            List<Review> reviews = new List<Review>();
            List<ReviewInfo> reviewsInfo = new List<ReviewInfo>();

            try
            {
                // 1) Dependency injection
                Storage storage = new Storage(new DBUtility());

                // 2) Get list of reviews from database based on restaurant id
                reviews = storage.GetReviewModels(id);

                // 3) Convert list of review models to list of review output objects
                reviewsInfo = ConvertModels.GetReviewInfos(reviews);
            }
            catch (InvalidParameterException e) { logger.Error(e.Message); }
            catch (InvalidCommandException e) { logger.Error(e.Message); }
            catch (InvalidInputException e) { logger.Error(e.Message); }
            catch (DbException e) { logger.Error(e.Message); }
            catch (Exception e) { logger.Error(e.Message); }

            // 4) Return response to client
            return reviewsInfo;
        }
    }
}

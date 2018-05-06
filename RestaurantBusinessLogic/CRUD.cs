using RestaurantDataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusinessLogic
{
    public static class CRUD
    {
        public static void AddRestaurant(RestaurantInfo r)
        {
            Storage storage = new Storage(new DBUtility());
            storage.AddRestaurant((Restaurant)r);
        }

        public static void UpdateRestaurant(RestaurantInfo r)
        {
            Storage storage = new Storage(new DBUtility());
            storage.EditRestaurant((Restaurant)r, r.id);
        }

        public static void DeleteRestaurant(int id)
        {
            Storage storage = new Storage(new DBUtility());
            storage.DeleteRestaurant(id);
        }

        public static void AddReview(ReviewInfo r)
        {
            Storage storage = new Storage(new DBUtility());
            storage.AddReview((Review)r);
        }

        public static void UpdateReview(ReviewInfo r)
        {
            Storage storage = new Storage(new DBUtility());
            storage.EditReview((Review)r, r.ReviewId);
        }

        public static void DeleteReview(int id)
        {
            Storage storage = new Storage(new DBUtility());
            storage.DeleteReview(id);
        }
    }
}

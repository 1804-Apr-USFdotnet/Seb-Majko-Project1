using System.Collections.Generic;
using System.Linq;
using RestaurantBusinessLogic;

namespace RestaurantMVC.Models
{
    public struct Restaurant
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<Review> Reviews { get; set; }

            /**********************************
             **                              **
             **             CRUD             **
             **                              **
             **********************************/

        public static void Add(Restaurant r)
        {
            CRUD.AddRestaurant(ToDB(r));
        }

        public static void Update(Restaurant r)
        {
            CRUD.UpdateRestaurant(ToDB(r));
        }

        public static void Delete(int id)
        {
            CRUD.DeleteRestaurant(id);
        }

            /**********************************
             **                              **
             **             GET              **
             **                              **
             **********************************/

        public static List<Restaurant> TopThree()
        {
            List<Restaurant> r = ToWebList(ProcessInput.GetRestaurants("restaurants", "top", "3"));
            return r;
        }

        public static List<Restaurant> GetRestaurants(params string[] sortParams)
        {
            List<Restaurant> r = ToWebList(ProcessInput.GetRestaurants(sortParams));
            return r;
        }

        public static List<Restaurant> SearchRestaurants(string query)
        {
            List<Restaurant> r = ToWebList(ProcessInput.GetRestaurants("restaurants", "contains", query));
            return r;
        }

            /**********************************
             **                              **
             **           CONVERT            **
             **                              **
             **********************************/

        private static List<Restaurant> ToWebList(List<RestaurantInfo> r)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var res in r)
            {
                restaurants.Add(ToWeb(res));
            }
            return restaurants;
        }

        private static Restaurant ToWeb(RestaurantInfo rInfo)
        {
            Restaurant r = new Restaurant
            {
                id = rInfo.id,
                Name = rInfo.Name,
                Address = rInfo.Address,
                Rating = rInfo.Rating,
                Image = rInfo.Image,
                //Reviews = rInfo.Reviews.Cast<Review>().ToList()
            };
            return r;
        }

        private static RestaurantInfo ToDB(Restaurant r)
        {
            RestaurantInfo rInfo = new RestaurantInfo
            {
                id = r.id,
                Name = r.Name,
                Address = r.Address,
                Image = r.Image
            };
            return rInfo;
        }
    }
}

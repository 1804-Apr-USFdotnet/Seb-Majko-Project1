using RestaurantDataLogic;
using System.Collections.Generic;

namespace RestaurantBusinessLogic
{
    public struct RestaurantInfo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public List<ReviewInfo> Reviews { get; set; }

        // Convert from Restaurant entity model to RestaurantInfo
        public static explicit operator RestaurantInfo(Restaurant r)
        {
            RestaurantInfo rout = new RestaurantInfo();
            rout.id = r.id;
            rout.Name = r.Name;
            rout.Address = r.Address;
            rout.Rating = (double)r.Rating;
            rout.Image = r.Image;
            //rout.Reviews = r.Reviews.Cast<ReviewInfo>().ToList();

            return rout;
        }

        public static explicit operator Restaurant(RestaurantInfo r)
        {
            Restaurant rout = new Restaurant();
            rout.id = r.id;
            rout.Name = r.Name;
            rout.Address = r.Address;
            rout.Rating = (double)r.Rating;
            rout.Image = r.Image;

            return rout;
        }
    }
}

using RestaurantBusinessLogic;
using System.Collections.Generic;

namespace RestaurantMVC.Models
{
    public struct Review
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }

        public static explicit operator Review(ReviewInfo rout)
        {
            Review r = new Review();
            r.Name = rout.Name;
            r.Summary = rout.Summary;
            r.Rating = (double)rout.Rating;

            return r;
        }

        /**********************************
         **                              **
         **             GET              **
         **                              **
         **********************************/

        public static List<Review> GetReviews(int id)
        {
            List<Review> r = ToWebList(ProcessInput.GetReviews(id));
            return r;
        }

        /**********************************
         **                              **
         **           CONVERT            **
         **                              **
         **********************************/

        private static List<Review> ToWebList(List<ReviewInfo> r)
        {
            List<Review> restaurants = new List<Review>();
            foreach (var res in r)
            {
                restaurants.Add(ToWeb(res));
            }
            return restaurants;
        }

        private static Review ToWeb(ReviewInfo rInfo)
        {
            Review r = new Review
            {
                Name = rInfo.Name,
                Summary = rInfo.Summary,
                Rating = rInfo.Rating,
            };
            return r;
        }
    }
}

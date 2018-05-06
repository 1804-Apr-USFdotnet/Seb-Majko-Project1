using RestaurantBusinessLogic;
using System.Collections.Generic;

namespace RestaurantMVC.Models
{
    public struct Review
    {
        public int RestaurantId { get; set; }
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }

        public static explicit operator Review(ReviewInfo rout)
        {
            Review r = new Review();
            r.RestaurantId = rout.RestaurantId;
            r.ReviewId = rout.ReviewId;
            r.Name = rout.Name;
            r.Summary = rout.Summary;
            r.Rating = (double)rout.Rating;

            return r;
        }

        /**********************************
         **                              **
         **             CRUD             **
         **                              **
         **********************************/

        public static void Add(Review r)
        {
            CRUD.AddReview(ToDB(r));
        }

        public static void Update(Review r)
        {
            CRUD.UpdateReview(ToDB(r));
        }

        public static void Delete(int id)
        {
            CRUD.DeleteReview(id);
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
                ReviewId = rInfo.ReviewId,
                RestaurantId = rInfo.RestaurantId,
                Name = rInfo.Name,
                Summary = rInfo.Summary,
                Rating = rInfo.Rating,
            };
            return r;
        }

        private static ReviewInfo ToDB(Review r)
        {
            ReviewInfo rInfo = new ReviewInfo
            {
                ReviewId = r.ReviewId,
                RestaurantId = r.RestaurantId,
                Name = r.Name,
                Summary = r.Summary,
                Rating = r.Rating
            };
            return rInfo;
        }
    }
}

using RestaurantBusinessLogic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMVC.Models
{
    public struct Review
    {
        public int RestaurantId { get; set; }
        public int ReviewId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Cannot be more than 50 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Cannot be more than 200 characters")]
        public string Summary { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Price must be between 0 and 100.00")]
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

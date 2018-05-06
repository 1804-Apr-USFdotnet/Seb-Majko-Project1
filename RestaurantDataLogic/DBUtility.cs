using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace RestaurantDataLogic
{
    public class DBUtility : IUtility
    {
        /// <summary>
        /// Add restaurant
        /// </summary>
        /// <returns>Id of added restaurant</returns>
        public int AddRestaurant(Restaurant r)
        {
            using (var db = new RestaurantsEntities())
            {
                db.Restaurants.Add(r);
                db.SaveChanges();
                return r.id;
            }
        }

        /// <summary>
        /// Edit restaurant based on edited fields
        /// </summary>
        /// <param name="r">Restaurant with updated info</param>
        /// <param name="restaurantId">Restaurant id</param>
        public void EditRestaurant(Restaurant r, int restaurantId)
        {
            using (var db = new RestaurantsEntities())
            {
                Restaurant res = GetRestaurantModels().SingleOrDefault(x => x.id == restaurantId);
                res.Name = r.Name;
                res.Address = r.Address;

                db.Restaurants.Attach(res);
                db.Entry(res).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete restaurant based on id
        /// </summary>
        /// <param name="id">Restaurant id</param>
        public void DeleteRestaurant(int id)
        {
            using (var db = new RestaurantsEntities())
            {
                Restaurant r = GetRestaurantModels().SingleOrDefault(x => x.id == id);
                db.Restaurants.Attach(r);
                db.Restaurants.Remove(r);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Add review to database
        /// </summary>
        /// <returns>Id of added review</returns>
        public void AddReview(Review r)
        {
            try
            {
                using (var db = new RestaurantsEntities())
                {
                    db.Reviews.Add(r);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// Edit review based on changed fields
        /// </summary>
        /// <param name="r">Review with updated info</param>
        /// <param name="reviewId">Review id</param>
        public void EditReview(Review r, int reviewId)
        {
            using (var db = new RestaurantsEntities())
            {
                Review rev = GetReviewModels().SingleOrDefault(x => x.ReviewId == reviewId);
                rev.Name = r.Name;
                rev.Rating = r.Rating;
                rev.Summary = r.Summary;

                db.Reviews.Attach(rev);
                db.Entry(rev).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes review based on id
        /// </summary>
        /// <param name="id">Review id</param>
        public void DeleteReview(int id)
        {
            using (var db = new RestaurantsEntities())
            {
                Review r = GetReviewModels().SingleOrDefault(x => x.ReviewId == id);
                db.Reviews.Attach(r);
                db.Reviews.Remove(r);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get restaurant id using name
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <returns>Restaurant id</returns>
        public int GetRestaurantId(string restaurantName)
        {
            using (var db = new RestaurantsEntities())
            {
                return db.Restaurants.SingleOrDefault(r => r.Name == restaurantName).id;
            }
        }

        /// <summary>
        /// Get all restaurants from database
        /// </summary>
        /// <returns>List of all Restaurants</returns>
        public List<Restaurant> GetRestaurantModels()
        {
            using (var db = new RestaurantsEntities())
            {
                return db.Restaurants.ToList();
            }
        }

        /// <summary>
        /// Get all reviews from database
        /// </summary>
        /// <returns>List of all reviews</returns>
        public List<Review> GetReviewModels()
        {
            using (var db = new RestaurantsEntities())
            {
                return db.Reviews.ToList();
            }
        }

        /// <summary>
        /// Get reviews from a restaurant using restaurant id
        /// </summary>
        /// <returns>List of reviews</returns>
        public List<Review> GetReviewModels(int restaurantId)
        {
            using (var db = new RestaurantsEntities())
            {
                return db.Reviews.AsNoTracking().Where(e => e.id.Equals(restaurantId)).ToList();
            }
        }
    }
}

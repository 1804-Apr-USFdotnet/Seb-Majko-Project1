using RestaurantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantMVC.Controllers
{
    public class ReviewController : Controller
    {
        public ActionResult Reviews(int id)
        {
            List<Review> r = Review.GetReviews(id);
            TempData["id"] = id;
            return View(r);
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review r)
        {
            try
            {
                Review.Add(r);
                return RedirectToAction("Reviews", new { id = r.RestaurantId });
            }
            catch
            {
                return RedirectToAction("Reviews", new { id = r.RestaurantId });
            }
        }

        public ActionResult Edit(int reviewId, int restaurantId, string name, string summary, double rating)
        {
            Review r = new Review { ReviewId = reviewId, RestaurantId = restaurantId, Name = name, Summary = summary, Rating = rating };
            TempData["r"] = r;
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: Review/Edit/
        [HttpPost]
        public ActionResult Edit(Review r)
        {
            try
            {
                Review.Update(r);
                return RedirectToAction("Reviews", new { id = r.RestaurantId });
            }
            catch
            {
                return RedirectToAction("Reviews", new { id = r.RestaurantId });
            }
        }

        // GET: Review/Delete/
        [HttpPost]
        public ActionResult Delete(int id, int resId)
        {
            Review.Delete(id);
            return RedirectToAction("Reviews", new { id = resId });
        }
    }
}
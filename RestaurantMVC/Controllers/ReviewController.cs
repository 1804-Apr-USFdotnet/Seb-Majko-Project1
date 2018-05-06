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
                return View(r);
            }
        }

        // POST: Review/Edit/
        [HttpPost]
        public ActionResult Edit(Review r)
        {
            try
            {
                Review.Update(r);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
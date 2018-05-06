using RestaurantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantMVC.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            Restaurant r = new Restaurant();
            return View();
        }

        public ActionResult Restaurants()
        {
            List<Restaurant> r = TempData["restaurants"] as List<Restaurant>;
            if (r == null) { r = Restaurant.GetRestaurants("restaurants"); }
            return View(r);
        }

        [HttpPost]
        public ActionResult RestaurantsSearch(string search = "")
        {
            List<Restaurant> r = Restaurant.GetRestaurants("restaurants", "contains", search);
            TempData["restaurants"] = r;
            return RedirectToAction("Restaurants");
        }

        [HttpPost]
        public ActionResult RestaurantsSort(bool name = true, bool asc = true)
        {
            List<Restaurant> r = new List<Restaurant>();
            switch (name)
            {
                case true:
                    switch (asc)
                    {
                        case true:
                            r = Restaurant.GetRestaurants("restaurants", "sortby", "name", "asc");
                            break;
                        case false:
                            r = Restaurant.GetRestaurants("restaurants", "sortby", "name", "desc");
                            break;
                    }
                    break;
                case false:
                    switch (asc)
                    {
                        case true:
                            r = Restaurant.GetRestaurants("restaurants", "sortby", "rating", "asc");
                            break;
                        case false:
                            r = Restaurant.GetRestaurants("restaurants", "sortby", "rating", "desc");
                            break;
                    }
                    break;
            }
            TempData["restaurants"] = r;
            return RedirectToAction("Restaurants");
            //return Restaurants(r);
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant r)
        {
            try
            {
                // TODO: Add insert logic here
                Restaurant.Add(r);
                return RedirectToAction("Restaurants");
            }
            catch
            {
                return View(r);
            }
        }


        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant r)
        {
            try
            {
                // TODO: Add update logic here
                Restaurant.Update(r);
                return RedirectToAction("Restaurants");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Restaurant.Delete(id);
            return RedirectToAction("Restaurants");
        }
    }
}

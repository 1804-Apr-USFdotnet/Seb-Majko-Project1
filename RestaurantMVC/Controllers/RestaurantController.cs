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
            return View("Index");
        }

        public ActionResult Restaurants()
        {
            List<Restaurant> r = TempData["restaurants"] as List<Restaurant>;
            if (r == null) { r = Restaurant.GetRestaurants("restaurants"); }
            return View("Restaurants", r);
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
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant r)
        {
            if (ModelState.IsValid) Restaurant.Add(r);
            return RedirectToAction("Restaurants");
        }

        public ActionResult Edit(int Id, string name, string address, string image)
        {
            Restaurant r = new Restaurant { id = Id, Name = name, Address = address, Image = image };
            TempData["r"] = r;

            return RedirectToAction("Restaurants");
        }


        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(Restaurant r)
        {
            if (ModelState.IsValid) Restaurant.Update(r);
            return RedirectToAction("Restaurants");
        }

        // GET: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid) Restaurant.Delete(id);
            return RedirectToAction("Restaurants");
        }
    }
}

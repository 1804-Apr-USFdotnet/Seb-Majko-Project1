using RestaurantMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RestaurantMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", Restaurant.TopThree());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Restaurants()
        {
            List<Restaurant> r = Restaurant.GetRestaurants();
            return RedirectToAction("Restaurants", "Restaurant");
        }
    }
}
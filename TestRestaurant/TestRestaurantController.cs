using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantMVC.Controllers;
using RestaurantMVC.Models;

namespace TestRestaurant
{
    [TestClass]
    public class TestRestaurantController
    {
        [TestMethod]
        public void TestRestaurants()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            string expected = "Restaurants";

            //Act
            var action = controller.Restaurants() as ViewResult;
            string actualViewName = action.ViewName;

            //Assert
            Assert.AreEqual(expected, actualViewName);
        }

        [TestMethod]
        public void TestRestaurantsData()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            Object expectedTempData = null;

            //Act
            var action = controller.Index() as ViewResult;
            Object actualTempData = action.TempData["restaurants"];

            //Assert
            Assert.AreEqual(expectedTempData, actualTempData);
        }

        [TestMethod]
        public void TestRestaurantsIndex()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            string expected = "Index";

            //Act
            var action = controller.Index() as ViewResult;
            string actualViewName = action.ViewName;

            //Assert
            Assert.AreEqual(expected, actualViewName);
        }

        [TestMethod]
        public void TestRestaurantsSearch()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            string expected = "Restaurants";

            //Act
            var action = (RedirectToRouteResult)controller.RestaurantsSearch("test");
            string actual = action.RouteValues["action"].ToString();


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRestaurantsSort()
        {
            //Arrange
            RestaurantController controller = new RestaurantController();
            string expected = "Restaurants";

            //Act
            var action = (RedirectToRouteResult)controller.RestaurantsSort(true, true);
            string actual = action.RouteValues["action"].ToString();


            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

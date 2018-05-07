using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantMVC.Controllers;
using RestaurantMVC.Models;

namespace TestRestaurant
{
    [TestClass]
    public class TestReviewController
    {
        [TestMethod]
        public void TestReviews()
        {
            //Arrange
            ReviewController controller = new ReviewController();
            string expected = "Reviews";

            //Act
            var action = controller.Reviews(0) as ViewResult;
            string actualViewName = action.ViewName;

            //Assert
            Assert.AreEqual(expected, actualViewName);
        }

        [TestMethod]
        public void TestCreate()
        {
            //Arrange
            ReviewController controller = new ReviewController();
            string expected = "Reviews";

            //Act
            var action = (RedirectToRouteResult)controller.Create(new Review());
            string actual = action.RouteValues["action"].ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEdit()
        {
            //Arrange
            ReviewController controller = new ReviewController();
            string expected = "Reviews";

            //Act
            var action = (RedirectToRouteResult)controller.Edit(new Review());
            string actual = action.RouteValues["action"].ToString();

            //Assert
            Assert.AreEqual(expected, actual);
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
        public void TestIndex()
        {
            //Arrange
            HomeController controller = new HomeController();
            string expected = "Index";

            //Act
            var action = controller.Index() as ViewResult;
            string actualViewName = action.ViewName;

            //Assert
            Assert.AreEqual(expected, actualViewName);
        }
    }
}

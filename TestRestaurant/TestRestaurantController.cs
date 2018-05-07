using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantMVC.Controllers;

namespace TestRestaurant
{
    [TestClass]
    public class TestRestaurantController
    {
        [TestMethod]
        public void TestIndex()
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
        public void TestIndexData()
        {
            //Arrange
            HomeController controller = new HomeController();
            string expectedTempData = ".Net Full Stack";
            //Act
            var action = controller.Index() as ViewResult;
            string actualTempData = action.TempData["Training"].ToString();
            //Assert
            Assert.AreEqual(expectedTempData, actualTempData);
        }
    }
}

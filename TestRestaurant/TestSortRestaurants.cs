using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RestaurantBusinessLogic;

namespace TestRestaurant
{
    [TestClass]
    public class TestSortRestaurants
    {
        static RestaurantInfo dummy1;
        static RestaurantInfo dummy2;
        static RestaurantInfo dummy3;
        static RestaurantInfo dummy4;
        static RestaurantInfo dummy5;
        static List<RestaurantInfo> actualList1;
        static List<RestaurantInfo> actualList2;
        static List<RestaurantInfo> actualList3;

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            dummy1 = new RestaurantInfo { Name = "McDonalds", Address = "65 Some Street", Rating = 2.8 };
            dummy2 = new RestaurantInfo { Name = "Wendys", Address = "11 Apple Avenue", Rating = 3.6 };
            dummy3 = new RestaurantInfo { Name = "Dunkin Donuts", Address = "23 America Drive Plaza", Rating = 3.5 }; ;
            dummy4 = new RestaurantInfo { Name = "Subway", Address = "113 Benjamin Boulevard", Rating = 4.1 }; ;
            dummy5 = new RestaurantInfo { Name = "Five Guys", Address = "211 Daytona Street", Rating = 4.8 }; ;
            actualList1 = new List<RestaurantInfo> { dummy1, dummy2, dummy3, dummy4, dummy5 };
            actualList2 = new List<RestaurantInfo> { dummy1, dummy2, dummy3, dummy4, dummy5 };
            actualList3 = new List<RestaurantInfo> { dummy1, dummy2, dummy3, dummy4, dummy5 };
        }

        [TestMethod]
        public void TestSortBy()
        {
            // Arrange
            List<RestaurantInfo> expectedList = new List<RestaurantInfo> { dummy1, dummy3, dummy2, dummy4, dummy5 };

            // Act
            SortRestaurants.SortBy(ref actualList1, "rating", "asc");

            // Assert
            CollectionAssert.AreEqual(expectedList, actualList1);
           
        }

        [TestMethod]
        public void TestTop()
        {
            // Arrange
            List<RestaurantInfo> expectedList = new List<RestaurantInfo> { dummy5, dummy4, dummy2 };

            // Act
            SortRestaurants.Top(ref actualList2, 3);


            // Assert
            CollectionAssert.AreEqual(expectedList, actualList2);

        }
        [TestMethod]
        public void TestContains()
        {
            // Arrange
            List<RestaurantInfo> expectedList = new List<RestaurantInfo> { dummy1, dummy3 };

            // Act
            SortRestaurants.Contains(ref actualList3, "do");

            // Assert
            CollectionAssert.AreEqual(expectedList, actualList3);

        }
    }
}

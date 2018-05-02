using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantBusinessLogic;

namespace TestRestaurant
{
    [TestClass]
    public class TestValidateInput
    {
        [TestMethod]
        public void TestValidateCommand()
        {
            bool expected1 = true;
            bool expected2 = true;
            bool expected3 = false;
            bool expected4 = false;

            //bool actual1 = ValidateInput.ValidateCommand(new string[] { "restaurants", "param1" });
            //bool actual2 = ValidateInput.ValidateCommand(new string[] { "reviews", "restaurant", "name" });
            //bool actual3 = ValidateInput.ValidateCommand(new string[] { "reviews" });
            //bool actual4 = ValidateInput.ValidateCommand(new string[] { "test" });

            //Assert.AreEqual(expected1, actual1);
            //Assert.AreEqual(expected2, actual2);
            //Assert.AreEqual(expected3, actual3);
            //Assert.AreEqual(expected4, actual4);
        }
    }
}

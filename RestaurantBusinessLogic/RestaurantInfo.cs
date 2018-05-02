using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    public struct RestaurantInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        // Convert from Restaurant entity model to RestaurantInfo
        public static explicit operator RestaurantInfo(Restaurant r)
        {
            RestaurantInfo rout = new RestaurantInfo();
            rout.Name = r.Name;
            rout.Address = r.Address;
            rout.Rating = (double)r.Rating;

            return rout;
        }
    }
}

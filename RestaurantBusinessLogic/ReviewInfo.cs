using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    public struct ReviewInfo
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }

        // Convert from Review entity model to ReviewInfo
        public static explicit operator ReviewInfo(Review r)
        {
            ReviewInfo rout = new ReviewInfo();
            rout.Name = r.Name;
            rout.Summary = r.Summary;
            rout.Rating = (double)r.Rating;

            return rout;
        }
    }
}

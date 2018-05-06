using RestaurantDataLogic;

namespace RestaurantBusinessLogic
{
    public struct ReviewInfo
    {
        public int RestaurantId { get; set; }
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }

        // Convert from Review entity model to ReviewInfo
        public static explicit operator ReviewInfo(Review r)
        {
            ReviewInfo rout = new ReviewInfo();
            rout.RestaurantId = r.id;
            rout.ReviewId = r.ReviewId;
            rout.Name = r.Name;
            rout.Summary = r.Summary;
            rout.Rating = (double)r.Rating;

            return rout;
        }

        public static explicit operator Review(ReviewInfo r)
        {
            Review rout = new Review();
            rout.id = r.RestaurantId;
            rout.Name = r.Name;
            rout.Summary = r.Summary;
            rout.Rating = (double)r.Rating;

            return rout;
        }
    }
}

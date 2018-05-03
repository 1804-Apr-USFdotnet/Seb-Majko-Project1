using RestaurantBusinessLogic;

namespace RestaurantMVC
{
    public struct Review
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public double Rating { get; set; }

        public static explicit operator Review(ReviewInfo rout)
        {
            Review r = new Review();
            r.Name = rout.Name;
            r.Summary = r.Summary;
            r.Rating = (double)r.Rating;

            return r;
        }
    }
}

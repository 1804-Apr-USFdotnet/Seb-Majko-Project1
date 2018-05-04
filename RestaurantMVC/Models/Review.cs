using RestaurantBusinessLogic;

namespace RestaurantMVC.Models
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
            r.Summary = rout.Summary;
            r.Rating = (double)rout.Rating;

            return r;
        }
    }
}

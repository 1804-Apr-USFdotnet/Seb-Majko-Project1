using RestaurantBusinessLogic.CustomExceptions;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantBusinessLogic
{
    static public class SortRestaurants
    {
        static public void Sort(ref List<RestaurantInfo> r, params string[] input)
        {
            switch (input[1])
            {
                case "sortby":
                    {
                        if (input.Length > 3)
                            if (input[2] == "rating" || input[2] == "name")
                                if (input[3] == "asc" || input[3] == "desc")
                                {
                                    SortBy(ref r, input[2], input[3]);
                                    break;
                                }
                    }
                    throw new InvalidParameterException();

                case "top":
                    {
                        int value;
                        if (int.TryParse(input[2], out value))
                            if (value > -1)
                            {
                                Top(ref r, value);
                                break;
                            }
                    }
                    throw new InvalidParameterException();

                case "contains":
                    {
                        if (input[2] != string.Empty)
                        {
                            Contains(ref r, input[2]);
                            break;
                        }
                    }
                    throw new InvalidParameterException();

                default:
                    throw new InvalidParameterException();
            }
        }

        static public void SortBy(ref List<RestaurantInfo> r, string orderby, string asc)
        {
            switch (orderby)
            {
                case "name":
                    if (asc == "asc") { r = r.OrderBy(x => x.Name).ToList(); }
                    else { r = r.OrderByDescending(x => x.Name).ToList(); }
                    break;

                case "rating":
                    if (asc == "asc") { r = r.OrderBy(x => x.Rating).ToList(); }
                    else { r = r.OrderByDescending(x => x.Rating).ToList(); }
                    break;
            }
        }

        static public void Top(ref List<RestaurantInfo> r, int top)
        {
            r = (from restaurant in r
                 orderby restaurant.Rating descending
                 select restaurant).Take(top).ToList();
        }

        static public void Contains(ref List<RestaurantInfo> r, string partial)
        {
            r = r.Where(w => partial.All(l => w.Name.ToLower().Contains(l))).ToList();
        }
    }
}

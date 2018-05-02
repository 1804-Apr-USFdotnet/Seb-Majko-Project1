using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RestaurantDataLogic
{
    public class LocalUtility //: IUtility
    {
        public int GetRestaurantId(string restaurantName)
        {
            string jsonData = System.IO.File.ReadAllText(@"C:\\jsondata\\ids.txt");
            Dictionary<string,int> ids = JsonConvert.DeserializeObject<Dictionary<string,int>>(jsonData);
            return ids[restaurantName];
        }

        /// <summary>
        /// Get all restaurants to process in business logic
        /// </summary>
        /// <returns>List of all Restaurants</returns>
        public List<Restaurant> GetRestaurantModels()
        {
            string jsonData = System.IO.File.ReadAllText(@"C:\\jsondata\\restaurants.txt");
            return JsonConvert.DeserializeObject<List<Restaurant>>(jsonData);
        }

        /// <summary>
        /// Get reviews from a restaurant
        /// </summary>
        /// <returns>List of reviews</returns>
        public List<Review> GetReviewModels(int restaurantId)
        {
            List<Review> reviews = new List<Review>();
            string jsonData = System.IO.File.ReadAllText(@"C:\\jsondata\\reviews.txt");
            List<Review> jsonReviews = JsonConvert.DeserializeObject<List<Review>>(jsonData);
            foreach (Review r in jsonReviews)
            {
                if (r.id == restaurantId)
                    reviews.Add(r);
            }
            return reviews;
        }

        public static void WriteToFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new JsonSerializer();
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}

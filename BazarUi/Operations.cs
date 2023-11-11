using BazarUi.Models;
using BazarUi.Utilties;

namespace BazarUi
{
    public class Operations
    {
        public void Search(string topic)
        {
            Console.WriteLine($"Searching for items related to topic: {topic}");
            var path = Environment.GetEnvironmentVariable("CATALOGURL");
            path = path + "/Search" + topic;
            string jsonResponse = GetJsonResponseFromApi(path, topic);

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                List<BookTopicSearchResult> searchResults =
                    JsonUtility.DeserializeSearchResults<BookTopicSearchResult>(jsonResponse);
                DisplaySearchResultsByTopic(searchResults);
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        private string GetJsonResponseFromApi(string path, string topic)
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };

            HttpClient httpClient = new HttpClient(socketsHandler);
            var result = httpClient.GetAsync(path).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        private string GetJsonResponseFromApi(string path)
        {
            var socketsHandler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2)
            };

            HttpClient httpClient = new HttpClient(socketsHandler);
            var result = httpClient.GetAsync(path).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        private void DisplaySearchResultsByTopic(List<BookTopicSearchResult> results)
        {
            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var result in results)
                {
                    Console.WriteLine($"Title: {result.Title}, Item Number: {result.ItemNumber}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        private void DisplaySearchResults(List<BookSearchResult> results)
        {
            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var result in results)
                {
                    Console.WriteLine(
                        $"Title: {result.Title}, Item Topic: {result.Topic}, Item Price : {result.Price}, Stock :{result.CopiesInStock} "
                    );
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        public void Info(int itemNumber)
        {
            Console.WriteLine($"Fetching info for item number: {itemNumber}");
            Console.WriteLine($"Searching for items related to topic: {itemNumber}");
            var path = Environment.GetEnvironmentVariable("CATALOGURL");
            path = path + "/Book" + itemNumber;
            string jsonResponse = GetJsonResponseFromApi(path);

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                List<BookSearchResult> searchResults =
                    JsonUtility.DeserializeSearchResults<BookSearchResult>(jsonResponse);
                DisplaySearchResults(searchResults);
            }
            else
            {
                Console.WriteLine("No results found.");
            }
            // Implement your info logic here
        }

        public void Purchase(int itemNumber)
        {
            Console.WriteLine($"Purchasing item with item number: {itemNumber}");
            // Implement your purchase logic here
        }
    }
}

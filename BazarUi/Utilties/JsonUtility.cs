using System.Text.Json;
using BazarUi.Models;

namespace BazarUi.Utilties
{
    public class JsonUtility
    {
        public static List<T> DeserializeSearchResults<T>(string json)
        {
            List<T> results = new List<T>();

            try
            {
                results = JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }

            return results;
        }
    }

}

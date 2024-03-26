using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Helpers
{
    public class JsonDataExtractor
    {
        public async Task<T> ExtractDataAsync<T>(string json)
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(json);
                T data = JsonConvert.DeserializeObject<T>(jsonContent);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                throw;
            }
        }

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    return imageBytes;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error downloading image: {ex.Message}");
                    throw;
                }
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class JsonDataExtractor
    {
        public async Task<List<T>> ExtractData<T>(string filePath, Func<T, Task> processDataAsync) where T : class
        {
            string jsonData = File.ReadAllText(filePath);
            List<T> extractedData = JsonConvert.DeserializeObject<List<T>>(jsonData);

            foreach (var item in extractedData)
            {
                await processDataAsync(item);
            }

            return extractedData;
        }

        public async Task<byte[]> DownloadImageAsByteArray(string imageUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(imageUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Failed to download image from {imageUrl}. Status code: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error downloading image: {ex.Message}");
                    return null;
                }
            }
        }
    }
}

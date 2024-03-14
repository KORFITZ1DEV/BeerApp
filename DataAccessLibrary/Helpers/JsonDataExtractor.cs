using Newtonsoft.Json;

namespace Helpers
{
    public class JsonDataExtractor
    {

        public List<T> extractData<T>(string filePath)
        {
            //Adding the Brewery data from beerdata.json 
            string JsonData = File.ReadAllText(filePath);
            //load in the json data file
            List<T> extractedData = JsonConvert.DeserializeObject<List<T>>(JsonData);

            return extractedData;
        }

    }
}



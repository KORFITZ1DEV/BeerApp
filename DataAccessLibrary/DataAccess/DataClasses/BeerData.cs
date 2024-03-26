using ModelLibrary;

namespace DataModels
{

    public class BeerData
    {
        public string BeerName { get; set; } = string.Empty;
        public BeerType BeerType { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? BeerImage { get; set; }
    }

}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    public enum BeerType
    {
        Light_Lager,
        Dark_Lager,
        Light_Ale,
        IPA,
        Dark_Ale,
        Wheat_beer,
        Sour_beer,
        Porter_Stout
    }

    [PrimaryKey("BeerID")]
    [Table("BEERS")]
    public class BeerModel
    {
        public Guid BeerID { get; set; }
        public string BeerName { get; set; } = string.Empty;
        public BeerType BeerType { get; set; }
        public string Description { get; set; } = string.Empty;
        public BreweryModel? Brewery { get; set; }
        public List<RatingModel>? Rating { get; set; }
        public byte[]? BeerImage { get; set; }
    }
}


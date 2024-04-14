using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    [PrimaryKey("BeerLoverID")]
    [Table("BEERLOVERS")]
    public class BeerLoverModel
    {
        public Guid BeerLoverID { get; set; }
        public string BeerLoverName { get; set; } = string.Empty;
        public string BeerLoverEmail { get; set; } = string.Empty;
        public List<BeerGroupModel>? BeerGroups { get; set; }
        public List<BeerModel>? FavoritBeers { get; set; }
        public List<BreweryModel>? FavoriteBreweries { get; set; }
        public List<RatingModel>? Ratings { get; set; }
        public byte[]? ProfilePic { get; set; }
    }

}
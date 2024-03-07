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
        public List<BreweryModel>? FavBrewery { get; set; }
        public List<BeerModel>? FavBeer { get; set; }
        public List<BeerGroupModel>? BeerGroup { get; set; }
        public List<RatingModel>? Rating { get; set; }
        public byte[]? ProfilePic { get; set; }
    }

}
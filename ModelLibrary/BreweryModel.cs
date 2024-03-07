using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    [PrimaryKey("BreweryID")]
    [Table("BREWERIES")]
    public class BreweryModel
    {
        public Guid BreweryID { get; set; }
        public string BreweryName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<BeerModel>? ProducedBeer { get; set; }

    }

}
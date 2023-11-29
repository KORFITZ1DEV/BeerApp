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
        public List<RatingModel>? rating { get; set; }

        public BeerLoverModel()
        {
            BeerLoverID = Guid.NewGuid();
        }
    }

}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    [PrimaryKey("RatingID")]
    [Table("RATINGS")]
    public class RatingModel
    {
        public Guid RatingID { get; set; }

        public double RatingScore { get; set; }

        public BeerModel Beer { get; set; } = null!;

        public BeerLoverModel Taster { get; set; } = null!;

        public DateTime RatingDate { get; set; }

        public string? Review { get; set; } = string.Empty;

        public RatingModel()
        {
            RatingID = Guid.NewGuid();
        }

    }
}

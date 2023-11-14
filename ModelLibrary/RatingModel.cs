using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    public class RatingModel
    {
        public Guid RatingID { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal RatingScore { get; set; }

        public BeerModel Beer { get; set; }

        public BeerLoverModel Taster { get; set; }

        public DateTime RatingDate { get; set; }

        public string? Review { get; set; }


    }
}


namespace ModelLibrary

public class RatingModel
{
    public Guid RatingID { get; set; }
    public float RatingScore { get; set; }

    public BeerModel Beer { get; set; }

    public BeerLoverModel Taster { get; set; }

    public DateTime RatingDate { get; set; }

    public string? Review { get; set; }


}
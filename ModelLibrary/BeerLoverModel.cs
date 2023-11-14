
namespace ModelLibrary

public class BeerLoverModel
{
    public Guid BeerLoverID { get; set; }
    public string BeerLoverName { get; set; }
    public string BeerLoverEmail { get; set; }
    public List<BeerGroupModel>? BeerGroups { get; set; }
    public List<RatingModel>? rating { get; set; }
}
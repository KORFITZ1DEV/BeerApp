using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    [PrimaryKey("BeerGroupID")]
    [Table("BEERGROUPS")]
    public class BeerGroupModel
    {
        public Guid BeerGroupID { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public List<BeerLoverModel> GroupMembers { get; set; } = new();

        public BeerGroupModel()
        {
            BeerGroupID = Guid.NewGuid();
        }
    }
}
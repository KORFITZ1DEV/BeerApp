using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary

public class BeerGroupModel
{
    public Guid BeerGroupID { get; set; }
    public string GroupName { get; set; }
    public List<BeerLoverModel> GroupMembers { get; set; }

}
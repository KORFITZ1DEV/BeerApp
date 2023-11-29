using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModelLibrary
{
    public enum BeerType
    {
        ALE,
        LAGER,
        SPECIALTY_HYBRID,
        STRONG_ALE
    }

    public enum AleSubType
    {
        PALE_ALE,
        INDIA_PALE_ALE,
        BROWN_ALE,
        PORTER,
        STOUT,
        BELGIAN_ALE,
        SAISON,
        WHEAT_BEER,
        BARLEYWINE
    }

    public enum LagerSubType
    {
        PILSNER,
        HELLES,
        BOCK,
        AMBER_LAGER,
        DARK_LAGER
    }

    public enum SpecialtyHybridSubType
    {
        FRUIT_BEER,
        SPICED_HERB_VEGETABLE_BEER,
        HYBRID_BEER,
        SOUR_BEER
    }

    public enum StrongAleSubType
    {
        ABBEY_TRAPPIST_ALE,
        OLD_ALE
    }

    [PrimaryKey("BeerID")]
    [Table("BEERS")]
    public class BeerModel
    {
        public Guid BeerID { get; set; }
        public string BeerName { get; set; } = string.Empty;

        public BeerType BeerType { get; set; }
        public AleSubType? AleSubType { get; set; }
        public LagerSubType? LagerSubType { get; set; }
        public SpecialtyHybridSubType? SpecialtyHybridSubType { get; set; }
        public StrongAleSubType? StrongAleSubType { get; set; }

        public string Brewery { get; set; } = string.Empty;
        public List<RatingModel>? Ratings { get; set; }

        public BeerModel()
        {
            BeerID = Guid.NewGuid();
        }
        public BeerModel(Guid beerId, string beerName, BeerType beerType)
        {
            BeerID = beerId;
            BeerName = beerName;
            BeerType = beerType;
        }

        public static BeerModel CreateAle(Guid beerId, string beerName, AleSubType aleSubType)
        {
            BeerModel beer = new BeerModel(beerId, beerName, BeerType.ALE);
            beer.AleSubType = aleSubType;
            return beer;
        }

        public static BeerModel CreateLager(Guid beerId, string beerName, LagerSubType lagerSubType)
        {
            BeerModel beer = new BeerModel(beerId, beerName, BeerType.LAGER);
            beer.LagerSubType = lagerSubType;
            return beer;
        }

        public static BeerModel CreateSpecialtyHybrid(Guid beerId, string beerName, SpecialtyHybridSubType specialtyHybridSubType)
        {
            BeerModel beer = new BeerModel(beerId, beerName, BeerType.SPECIALTY_HYBRID);
            beer.SpecialtyHybridSubType = specialtyHybridSubType;
            return beer;
        }

        public static BeerModel CreateStrongAle(Guid beerId, string beerName, StrongAleSubType strongAleSubType)
        {
            BeerModel beer = new BeerModel(beerId, beerName, BeerType.STRONG_ALE);
            beer.StrongAleSubType = strongAleSubType;
            return beer;
        }
    }
}

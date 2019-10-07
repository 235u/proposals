using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public sealed class RingInfo
    {
        public PreciousMetalInfo Metal { get; set; } =
            new PreciousMetalInfo(PreciousMetal.Gold, PreciousMetalFineness.TwentyTwoKarat);

        [Display(Name = "Type")]
        public RingType RingType { get; set; }

        public DiamondInfo Diamond { get; set; } = new DiamondInfo();

        public decimal PriceInDirhams
        {
            get
            {                
                return Diamond.PriceInDirhams + 
                    RingPriceInfo.MetalPriceAdditions[Metal] +
                    RingPriceInfo.TypePriceAdditions[RingType];
            }
        }
    }
}

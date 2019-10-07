using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public enum RingType
    {
        [Display(Name = "With Side Stones")]
        WithSideStones,

        [Display(Name = "Without Side Stones")]
        WithoutSideStones
    }
}

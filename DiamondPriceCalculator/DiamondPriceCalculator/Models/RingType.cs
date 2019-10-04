using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public enum RingType
    {
        [Display(Name = "With Side Stones")]
        WithSideStones,

        [Display(Name = "Without Side Stones")]
        WithoutSideStones
    }
}

using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public enum PreciousMetalFineness
    {
        [Display(Name = "22kt")]
        TwentyTwoKarat,

        [Display(Name = "20kt")]
        TwentyKarat,

        [Display(Name = "18kt")]
        EighteenKarat,

        [Display(Name = "14kt")]
        FourteenKarat
    }
}

using System.ComponentModel.DataAnnotations;

namespace GamePriceComparison.Models
{
    public enum Currency
    {
        [Display(ShortName = "GBP")]
        PoundSterling,

        [Display(ShortName = "MXN")]
        MexicanPeso,

        [Display(ShortName = "RUB")]
        RussianRouble
    }
}

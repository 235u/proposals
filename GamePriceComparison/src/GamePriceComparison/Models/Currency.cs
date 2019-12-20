using System.ComponentModel.DataAnnotations;

namespace SteamPriceComparison.Models
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

using System.ComponentModel.DataAnnotations;

namespace GamePriceComparison.Models
{
    public enum Country
    {
        [Display(Name = "U.K.", ShortName = "uk")]
        UnitedKingdom,

        [Display(ShortName = "ru")]
        Russia,

        [Display(ShortName = "mx")]
        Mexico,
    }
}

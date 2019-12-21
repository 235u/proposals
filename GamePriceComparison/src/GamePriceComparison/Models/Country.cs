using System.ComponentModel.DataAnnotations;

namespace GamePriceComparison.Models
{
    public enum Country
    {
        [Display(Name = "UK", ShortName = "uk")]
        UnitedKingdom,

        [Display(ShortName = "ru")]
        Russia,

        [Display(ShortName = "mx")]
        Mexico,
    }
}

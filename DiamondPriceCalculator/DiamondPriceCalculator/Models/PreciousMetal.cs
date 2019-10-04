using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public enum PreciousMetal
    {
        Gold,

        [Display(Name = "White Gold")]
        WhiteGold,

        Platinum
    }
}

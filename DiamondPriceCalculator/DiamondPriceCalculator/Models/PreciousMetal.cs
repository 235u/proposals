using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public enum PreciousMetal
    {
        Gold,

        [Display(Name = "White Gold")]
        WhiteGold,

        Platinum
    }
}

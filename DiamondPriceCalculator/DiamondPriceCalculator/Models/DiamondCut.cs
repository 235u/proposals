using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public enum DiamondCut
    {
        [Display(Name = "Astor Ideal")]
        AstorIdeal,

        Ideal,

        [Display(Name = "Very Good")]
        VeryGood,

        Good
    }
}

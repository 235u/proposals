using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public enum DiamondClarity
    {
        [Display(GroupName = "Internally Flawless")]
        IF,

        [Display(GroupName = "Very, Very Slightly Included")]
        VVS1,

        [Display(GroupName = "Very, Very Slightly Included")]
        VVS2,

        [Display(GroupName = "Very Slightly Included")]
        VS1,

        [Display(GroupName = "Very Slightly Included")]
        VS2,

        [Display(GroupName = "Slightly Included")]
        SI1,

        [Display(GroupName = "Slightly Included")]
        SI2,

        [Display(GroupName = "Included")]
        I1
    }
}

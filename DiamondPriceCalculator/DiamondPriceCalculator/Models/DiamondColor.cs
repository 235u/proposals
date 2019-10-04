using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    /// <summary>
    /// Represents diamond's colorlessness – the less color, the higher its value.
    /// </summary>
    /// <seealso href="https://www.gia.edu/gia-about-4cs-color"/>
    public enum DiamondColor
    {
        [Display(GroupName = "Colorless")]
        D,

        [Display(GroupName = "Colorless")]
        E,

        [Display(GroupName = "Colorless")]
        F,

        [Display(GroupName = "Near Colorless")]
        G,

        [Display(GroupName = "Near Colorless")]
        H,

        [Display(GroupName = "Near Colorless")]
        I,

        [Display(GroupName = "Near Colorless")]
        J,

        [Display(GroupName = "Faint")]
        K,

        [Display(GroupName = "Faint")]
        L,

        [Display(GroupName = "Faint")]
        M,

        [Display(GroupName = "Very Light")]
        N,

        [Display(GroupName = "Very Light")]
        O,

        [Display(GroupName = "Very Light")]
        P,

        [Display(GroupName = "Very Light")]
        Q,

        [Display(GroupName = "Very Light")]
        R,

        [Display(GroupName = "Light")]
        S,

        [Display(GroupName = "Light")]
        T,

        [Display(GroupName = "Light")]
        U,

        [Display(GroupName = "Light")]
        V,

        [Display(GroupName = "Light")]
        W,

        [Display(GroupName = "Light")]
        X,

        [Display(GroupName = "Light")]
        Y,

        [Display(GroupName = "Light")]
        Z
    }
}

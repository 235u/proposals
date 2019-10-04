using System;
using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public sealed class DiamondInfo
    {
        public DiamondInfo()
        {
        }

        /// <summary>
        /// One metric carat is equal to 0.2 grams, about the same weight as a paperclip.
        /// </summary>
        /// <remarks>
        /// Don't confuse carat with karat, as in <see cref="PreciousMetalFineness.EighteenKarat", which refers to gold
        /// purity.
        /// </remarks>
        /// <seealso href="https://www.gia.edu/gia-about/4cs-carat">GIA 4Cs Carat Weight</seealso>
        [Display(Name = "Weight")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal WeightInCarats { get; set; } = 0.5M;

        [Display(Name = "Dimensions")]
        public MeasurementInfo Measurements { get; set; } =
            new MeasurementInfo() 
            { 
                Length = 4.03M,
                Width = 4.01M,
                Height = 2.42M
            };

        public DiamondColor Color { get; set; } = DiamondColor.E;

        [Display(Name = "Quality")]
        public DiamondClarity Clarity { get; set; } = DiamondClarity.SI1;

        public DiamondShape Shape { get; set; } = DiamondShape.Round;

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal PriceInDirhams { get; set; } = 1228.95M;
    }
}

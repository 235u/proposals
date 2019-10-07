using System;
using System.ComponentModel.DataAnnotations;

namespace ActinUranium.Proposals.DiamondPriceCalculator.Models
{
    public sealed class DiamondInfo
    {
        public DiamondInfo()
        {
        }

        public DiamondShape Shape { get; set; } = DiamondShape.Round;

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "AED {0:F2}")]
        public decimal PriceInDirhams { get; set; } = 1228.95M;

        /// <summary>
        /// One metric carat is equal to 0.2 grams, about the same weight as a paperclip.
        /// </summary>
        /// <remarks>
        /// Don't confuse carat with karat, as in <see cref="PreciousMetalFineness.EighteenKarat", which refers to gold
        /// purity.
        /// </remarks>
        /// <seealso href="https://www.gia.edu/gia-about/4cs-carat">GIA 4Cs Carat Weight</seealso>
        [Display(Name = "Weight")]
        [DisplayFormat(DataFormatString = "{0:F2} ct")]
        public decimal WeightInCarats { get; set; } = 0.5M;

        public DiamondCut Cut { get; set; } = DiamondCut.AstorIdeal;

        public DiamondColor Color { get; set; } = DiamondColor.E;

        public DiamondClarity Clarity { get; set; } = DiamondClarity.SI1;
    }
}

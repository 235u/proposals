using System.ComponentModel.DataAnnotations;

namespace DiamondPriceCalculator.Web.Models
{
    public sealed class MeasurementInfo
    {
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Length { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Width { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Height { get; set; }

        public override string ToString()
        {
            return string.Format("{0:F2} x {1:F2} x {2:F2} mm", Length, Width, Height);
        }
    }
}

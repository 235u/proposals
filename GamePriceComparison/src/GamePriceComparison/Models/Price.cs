using GamePriceComparison.Helpers;

namespace GamePriceComparison.Models
{
    public struct Price
    {
        public Currency Currency;

        public decimal Value;

        public override string ToString()
        {            
            return $"{Value.ToString("F2")} {Currency.GetShortName()}";
        }
    }
}

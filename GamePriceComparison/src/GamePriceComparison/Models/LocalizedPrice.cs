namespace GamePriceComparison.Models
{
    public struct LocalizedPrice
    {
        public Price OriginalPrice { get; set; }

        public Price BasePrice { get; set; }
    }
}

namespace StockTickerStandard
{
    internal class StockTick
    {
        public StockTick(string quoteSymbol, decimal price)
        {
            QuoteSymbol = quoteSymbol;
            Price = price;
        }

        public string QuoteSymbol { get; }
        public decimal Price { get; }
    }
}
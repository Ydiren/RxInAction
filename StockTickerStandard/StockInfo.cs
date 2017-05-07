namespace StockTickerStandard
{
   internal class StockInfo
   {
      public StockInfo(string symbol, decimal prevPrice)
      {
         Symbol = symbol;
         PrevPrice = prevPrice;
      }

      public string Symbol { get; }
      public decimal PrevPrice { get; }
   }
}
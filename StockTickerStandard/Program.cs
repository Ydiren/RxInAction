namespace StockTickerStandard
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var stockTicker = new StockTicker();
            var stockMonitor = new StockMonitor(stockTicker);

            Console.ReadKey();
        }
    }
}
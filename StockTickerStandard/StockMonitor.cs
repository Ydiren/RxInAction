namespace StockTickerStandard
{
    using System;
    using System.Collections.Generic;

    internal class StockMonitor : IDisposable
    {
        private const decimal MaxChangeRatio = 0.1m;
        private readonly StockTicker _ticker;

        private readonly Dictionary<string, StockInfo> _stockInfos = new Dictionary<string, StockInfo>();

        public StockMonitor(StockTicker ticker)
        {
            _ticker = ticker;
            _ticker.StockTick += OnStockTick;
        }

        public void Dispose()
        {
            _ticker.StockTick -= OnStockTick;
            _stockInfos.Clear();
        }

        private void OnStockTick(object sender, StockTick changedStock)
        {
            var quoteSymbol = changedStock.QuoteSymbol;
            var stockInfoExists = _stockInfos.TryGetValue(quoteSymbol, out StockInfo stockInfo);

            if (stockInfoExists)
            {
                var priceDiff = changedStock.Price - stockInfo.PrevPrice;
                var percentageChange = Math.Abs(priceDiff / stockInfo.PrevPrice);

                if (percentageChange > MaxChangeRatio)
                {
                    Console
                        .WriteLine($"Stock:{quoteSymbol} has changed with ratio {percentageChange:F}\nOld price: {stockInfo.PrevPrice}, New price: {changedStock.Price}");
                }
            }

            _stockInfos[quoteSymbol] = new StockInfo(changedStock.QuoteSymbol, changedStock.Price);
        }
    }
}
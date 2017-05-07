namespace StockTickerStandard
{
    using System;
    using System.Collections.Generic;
    using System.Timers;

    internal class StockTicker : IDisposable
    {
        private readonly Timer _timer;

        private readonly Queue<StockTick> Stocks = new Queue<StockTick>(4);

        public StockTicker()
        {
            var interval = TimeSpan.FromSeconds(1)
                                   .TotalMilliseconds;
            _timer = new Timer(interval);
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();

            Stocks.Enqueue(new StockTick("MSFT", 100));
            Stocks.Enqueue(new StockTick("INTC", 150));
            Stocks.Enqueue(new StockTick("MSFT", 170));
            Stocks.Enqueue(new StockTick("MSFT", 195));
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer?.Dispose();
        }

        public event EventHandler<StockTick> StockTick;

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Stocks.Count > 0)
            {
                var nextStock = Stocks.Dequeue();
                StockTick?.Invoke(this, nextStock);
            }
        }
    }
}
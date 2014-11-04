// -----------------------------------------------------------------------
//  <copyright file="ObserverDelegate.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Behavioral
{
    using System;

    public class StockTickerDelegate
    {
        public static string UpdateStrMS = string.Empty;
        public static string UpdateStrGoog = string.Empty;
        public event EventHandler<StockTickerEventArgs> StockTickerEventHandler;

        protected virtual void OnNewStock(string symbol, decimal price)
        {
            if (this.StockTickerEventHandler != null)
            {
                this.StockTickerEventHandler(this, new StockTickerEventArgs(symbol, price));
            }
        }

        public void UpdateNewStock(Stock stock)
        {
            this.OnNewStock(stock.Symbol, stock.Price);
        }
    }

    public class StockTickerEventArgs
    {
        public StockTickerEventArgs(string symbol, decimal price)
        {
            this.Symbol = symbol;
            this.Price = price;
        }

        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }
}

// -----------------------------------------------------------------------
//  <copyright file="ObserverTest.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class ObserverTest
    {
        [TestMethod]
        public void ObserverTest1()
        {
            var ticker = new StockTicker();
            var msft = new MicrosoftObserver(ticker);
            var goog = new GoogleObserver(ticker);

            Stock stock = this.GetNewStockObject("MSFT", (decimal)10.1);
            ticker.Stock = stock;

            Assert.IsTrue(msft.UpdateStr == "MSFT" + stock.Price);
            Assert.IsTrue(goog.UpdateStr == "I am not the one");
        }

        [TestMethod]
        public void ObserverTest2()
        {
            var ticker = new StockTicker();
            var msft = new MicrosoftObserver(ticker);
            var goog = new GoogleObserver(ticker);

            Stock stock = this.GetNewStockObject("GOOG", (decimal)10.5);
            ticker.Stock = stock;

            Assert.IsTrue(goog.UpdateStr == "GOOG" + stock.Price);
            Assert.IsTrue(msft.UpdateStr == "I am not the one");
        }

        private Stock GetNewStockObject(string symbol, decimal price)
        {
            var stock = new Stock { Price = price, Symbol = symbol };
            return stock;
        }
    }
}

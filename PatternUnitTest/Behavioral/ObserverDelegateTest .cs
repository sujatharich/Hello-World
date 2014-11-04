namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class ObserverDelegateTest
    {
        [TestMethod]
        public void ObserverDelegateTest1()
        {
            var ticker = new StockTickerDelegate();
            this.AddHandlersStockTicker(ticker);

            Stock stock1 = this.GetNewStockObject("MSFT", (decimal)10.1);
            ticker.UpdateNewStock(stock1);

            Assert.IsTrue(StockTickerDelegate.UpdateStrMS == "MSFT" + stock1.Price);
            Assert.IsTrue(StockTickerDelegate.UpdateStrGoog == "I am not the one");
        }

        [TestMethod]
        public void ObserverDelegateTest2()
        {
            var ticker = new StockTickerDelegate();
            this.AddHandlersStockTicker(ticker);

            Stock stock2 = this.GetNewStockObject("GOOG", (decimal)10.5);
            ticker.UpdateNewStock(stock2);

            Assert.IsTrue(StockTickerDelegate.UpdateStrGoog == "GOOG" + stock2.Price);
            Assert.IsTrue(StockTickerDelegate.UpdateStrMS == "I am not the one");
        }

        private Stock GetNewStockObject(string symbol, decimal price)
        {
            var stock = new Stock { Price = price, Symbol = symbol };
            return stock;
        }

        private void AddHandlersStockTicker(StockTickerDelegate ticker)
        {
            ticker.StockTickerEventHandler += (r, e) =>
            {
                if (e.Symbol == "MSFT")
                {
                    StockTickerDelegate.UpdateStrMS = "MSFT" + e.Price;
                }
                else
                {
                    StockTickerDelegate.UpdateStrMS = "I am not the one";
                }
            };

            ticker.StockTickerEventHandler += (r, e) =>
            {
                if (e.Symbol == "GOOG")
                {
                    StockTickerDelegate.UpdateStrGoog = "GOOG" + e.Price;
                }
                else
                {
                    StockTickerDelegate.UpdateStrGoog = "I am not the one";
                }
            };
        }
    }
}

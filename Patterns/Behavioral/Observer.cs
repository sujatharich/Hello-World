namespace Patterns.Behavioral
{
    using System.Collections.Generic;


    // when changes to an object should allow notification to others with out any knowledge of them.

    public abstract class AbstractSubject
    {
        private readonly List<AbstractObserver> observers = new List<AbstractObserver>();

        public void Register(AbstractObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Unregister(AbstractObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update();
            }
        }
    }

    public class Stock
    {
        public decimal Price;
        public string Symbol;
    }

    public class StockTicker : AbstractSubject
    {
        private Stock stock;

        public Stock Stock
        {
            get { return this.stock; }
            set
            {
                this.stock = value;
                this.Notify();
            }
        }
    }

    public abstract class AbstractObserver
    {
        public const string Nostr = "I am not the one";
        public string UpdateStr = string.Empty;

        public abstract void Update();
    }

 
    public class MicrosoftObserver : AbstractObserver
    {
        private readonly StockTicker ticker;

        public MicrosoftObserver(StockTicker ticker)
        {
            this.ticker = ticker;
            this.ticker.Register(this);
        }

        public override void Update()
        {
            if (this.ticker.Stock.Symbol == "MSFT")
            {
                this.UpdateStr = "MSFT" + this.ticker.Stock.Price;
            }
            else
            {
                this.UpdateStr = AbstractObserver.Nostr;
            }
        }
    }

    public class GoogleObserver : AbstractObserver
    {
        private readonly StockTicker ticker;

        public GoogleObserver(StockTicker ticker)
        {
            this.ticker = ticker;
            this.ticker.Register(this);
        }

        public override void Update()
        {
            if (this.ticker.Stock.Symbol == "GOOG")
            {
                this.UpdateStr = "GOOG" + this.ticker.Stock.Price;
            }
            else
            {
                this.UpdateStr = AbstractObserver.Nostr;
            }
        }
    }
}

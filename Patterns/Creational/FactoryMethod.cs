using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational
{
    using System.Runtime.InteropServices;
    using System.Security.Cryptography.X509Certificates;

    public interface IActiveCount
    {
        List<double> GetActiveCount();
    }

    public  enum ActiveCountObject
    {
        Cosmos,
        Db
    }
    public  class CosmosActiveCount:IActiveCount
    {
        public List<double> GetActiveCount()
        {
            var activeCount = new List<double> { 1.0 };
            return activeCount;
        }
    }

    public class DBsActiveCount : IActiveCount
    {
        public List<double> GetActiveCount()
        {
            var activeCount = new List<double> { 2.0 };
            return activeCount;
        }
    }

    public abstract class FactoryMethod
    {
        abstract public IActiveCount GetActiveCountObject(ActiveCountObject objectType);
    }

    public  class ActiveCountFactory: FactoryMethod
    {
        public override IActiveCount GetActiveCountObject(ActiveCountObject objectType)
        {
            switch (objectType)
            {
                case ActiveCountObject.Cosmos:
                    return new CosmosActiveCount();
                case ActiveCountObject.Db:
                    return new DBsActiveCount();
                default:
                    throw new InvalidOperationException(" invalid object type" + objectType.ToString());
            }
        }
    }

}

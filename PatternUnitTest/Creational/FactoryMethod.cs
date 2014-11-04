

namespace PatternUnitTest.Creational
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Creational;
    using System;
    using System.Collections.Generic;


    [TestClass]
    public class FactoryMethod
    {
        [TestMethod]
        public void FactoryMethodTest()
        {
            /* factory method testing */
            var f = new ActiveCountFactory();
            List<double> counts = f.GetActiveCountObject(ActiveCountObject.Cosmos).GetActiveCount();
            Assert.IsTrue(Math.Abs(counts[0] - 1.0) < .0001);
            counts = f.GetActiveCountObject(ActiveCountObject.Db).GetActiveCount();
            Assert.IsTrue(counts[0] == 2.0);

        }
    }
}

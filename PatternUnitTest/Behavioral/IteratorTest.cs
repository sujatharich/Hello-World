// -----------------------------------------------------------------------
//  <copyright file="IteratorTest.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void ReverseIteratorTest()
        {
            var p = new IteratorPattern { Reverse = true };
            var r = p.GetEnumerator();
            int i = 9;
            while (r.MoveNext())
            {
                Assert.IsTrue(r.Current == i--);
            }
        }

        [TestMethod]
        public void IteratorRegularTest()
        {
            var p = new IteratorPattern();
            var r = p.GetEnumerator();
            int i = 0;
            while (r.MoveNext())
            {
                Assert.IsTrue(r.Current == i++);
            }
        }
    }
}

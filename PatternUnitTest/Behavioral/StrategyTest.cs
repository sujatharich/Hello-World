
namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void StrategyTest1()
        {
            Strategy s = new AdditionStrategy();
            var c = new Calculator(s);
            Assert.IsTrue(c.GetResult(5,3)==8);

            s = new SubstractionStrategy();
            c = new Calculator(s);
            Assert.IsTrue(c.GetResult(5, 3) == 2);

            s = new MultiplicationStrategy();
            c = new Calculator(s);
            Assert.IsTrue(c.GetResult(5, 3) == 15);

        }
    }
}


namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class InterpreterTest
    {
        [TestMethod]
        public void InterepreterTest1()
        {
            IExpression left = new NumberExpression("2");
            IExpression right = new NumberExpression(3);

            IExpression result = new PlusExpression(left, right);
            Assert.IsTrue(result.Interpret() == 5);

            result = new MinusExpression(left, right);
            Assert.IsTrue(result.Interpret() == -1);
        }

    }
}

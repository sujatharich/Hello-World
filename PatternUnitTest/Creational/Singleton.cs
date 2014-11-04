namespace PatternUnitTest.Creational
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Creational;

    [TestClass]
    public class SingletonTest
    {
        [TestMethod]
        public void MultiThreadTest()
        {
            /* singleton class testing */
            const int count = 1000;
            var result = new int[count];
            var s = new Singleton[count];
            Parallel.For(
                0,
                count,
                i =>
                {
                    s[i] = Singleton.Instance();
                    result[i] = s[i].GetValue();
                });

            const int expSum = count * (count + 1) / 2;
            int actSum = result.Sum();
            Assert.IsTrue(expSum == actSum);

        }
    }
}

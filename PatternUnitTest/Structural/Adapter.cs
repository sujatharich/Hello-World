namespace PatternUnitTest.Structural
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Structural;

    [TestClass]
    public class Adapter
    {
        [TestMethod]
        public void AdapterTest1()
        {
            var r = new RectangularPlug { Steam = 1 };
            Assert.IsTrue(r.GetPower() == "no power");
        }

        [TestMethod]
        public void AdapterTest2()
        {
            var r = new RectangularPlug { Steam = 2 };
            Assert.IsTrue(r.GetPower() == "power");
        }

        [TestMethod]
        public void AdapterTest3()
        {
            var r = new RectangularPlugComposition { Steam = 1 };
            Assert.IsTrue(r.GetPower() == "no power");
        }

        [TestMethod]
        public void AdapterTest4()
        {
            var r = new RectangularPlugComposition { Steam = 2 };
            Assert.IsTrue(r.GetPower() == "power");
        }
        
    }
}


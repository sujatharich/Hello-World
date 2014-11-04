
namespace PatternUnitTest.Behavioral
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Patterns.Behavioral;

    [TestClass]
    public class TemplateMethodTest
    {
        [TestMethod]
        public void TemplateMethodTest1()
        {
            CrossCompiler c = new IPhoneCompiler();
            Assert.IsTrue(c.Compile()=="iphone source compile");
            c = new AndroidCompiler();
            Assert.IsTrue(c.Compile() == "android source compile");
        }
    }
}

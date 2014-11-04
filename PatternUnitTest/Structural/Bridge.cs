
namespace PatternUnitTest.Structural
{
    using Patterns.Structural;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Bridge
    {
        [TestMethod]
        public void BridgeTest1()
        {
            ISender sender = new MailSender();
            var message = new MailMessage(sender);
            Assert.IsTrue(message.Send() == "mail sender");

            sender = new MessageSender();
            message = new MailMessage(sender);
            Assert.IsTrue(message.Send() == "message sender");
        }
    }

}

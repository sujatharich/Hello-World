using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural
{
    //    Adapter starts from letter 'A' - map with After and Bridge starts from letter 'B' map with Before. 
    //    Now when its Adapter its always to deal with the situation when some implementation is already in place and but some kind of hack 
    //    or patch or connector to put in place to make it work, like the real (electric) adapter.
    //    Where in bridge - its before hand - design should be such that interface and implementation both are independent 
    //    so abstraction is covered at interface level but actual implementation differs based on condition or need.
    public interface ISender
    {
        string SendMessage();
    }
    public class  MailSender: ISender
    {
        public string SendMessage()
        {
            return "mail sender";
        }
    }

    public class MessageSender : ISender
    {
        public string SendMessage()
        {
            return "message sender";
        }
    }

    public abstract class Message
    {
        private ISender sender;
        public Message(ISender sender)
        {
            this.sender = sender;
        }

        public abstract string Send();
    }

    public class MailMessage:Message
    {
        private ISender sender;
        public MailMessage(ISender sender)
            : base(sender)
        {
            this.sender = sender;
        }

        public override string Send()
        {
            return this.sender.SendMessage();
        }
    }

}

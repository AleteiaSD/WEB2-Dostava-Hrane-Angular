using MimeKit;
using System.Collections.Generic;
using System.Linq;
namespace WebApplication1.Service
{
    public class Message
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<MailboxAddress> To { get; set; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;
        }
    }
}

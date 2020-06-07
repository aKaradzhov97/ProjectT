namespace ProjectT.Services.Messaging
{
    using System.Collections.Generic;
    using System.Linq;

    using MimeKit;

    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            this.To = new List<MailboxAddress>();

            this.To.AddRange(to.Select(x => new MailboxAddress(x)));
            this.Subject = subject;
            this.Content = content;
        }
    }
}
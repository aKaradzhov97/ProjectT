namespace ProjectT.Services.Messaging
{
    public interface IEmailSender
    {
        void SendEmailAsync(Message message);
    }
}

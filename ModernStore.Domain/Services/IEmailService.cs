namespace ModernStore.Domain.Services
{
    public interface IEmailService
    {
        void Send(string toName, string toEmail, string subject, string body);
    }
}

using StackOverFlowClone.Email;

namespace StackOverFlowClone.Service.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mailrequest mailrequest);

    }
}

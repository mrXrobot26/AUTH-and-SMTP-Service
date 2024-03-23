
namespace StackOverFlowClone.Service.Email
{
    public interface IEmailHelper
    {
        Task SendEmail(string userEmail, string confirmationLink);
    }
}
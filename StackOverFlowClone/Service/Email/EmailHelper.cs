using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using StackOverFlowClone.Email;


namespace StackOverFlowClone.Service.Email
{
    public class EmailHelper : IEmailHelper
    {
        private readonly EmailSettings emailSettings;
        public EmailHelper(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;

        }
        public async Task SendEmail(string userEmail, string htmlBody)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Confirm your email";
            var builder = new BodyBuilder();

            // Assign the provided HTML body
            builder.HtmlBody = htmlBody;

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}

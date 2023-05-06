using Api.DTO;
using Api.Models;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;



namespace Api.Services
{
    public class EmailService : IEmailService
    {

        private readonly Email emailSettings;

        public EmailService(IOptions<Email> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }
        public void sendEmail(EmailDTO emailDTO)
        {
            foreach (var email in emailDTO.Emails)
            {
                var _email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(emailSettings.email),
                    Subject = emailDTO.Subject,
                };
                _email.To.Add(MailboxAddress.Parse(email));

                _email.Body = new TextPart(TextFormat.Html) { Text = emailDTO.MessageContent };
                _email.From.Add(new MailboxAddress(emailSettings.displayName, emailSettings.email));

                using var smtpClient = new SmtpClient();

                smtpClient.Connect(emailSettings.host, emailSettings.port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(emailSettings.email, emailSettings.password);
                smtpClient.Send(_email);
                smtpClient.Disconnect(true);
            }
        }
    }
}

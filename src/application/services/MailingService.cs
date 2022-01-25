using application.utils.Constants;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class MailingService : IMailingService
    {
        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(MailConstants.Email),
                    Subject = subject
                };

                email.To.Add(MailboxAddress.Parse(mailTo));
                var builder = new BodyBuilder();
                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                email.From.Add(new MailboxAddress(MailConstants.DisplayName, MailConstants.Email));

                using var smtp = new SmtpClient();
                smtp.Connect(MailConstants.Host, MailConstants.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(MailConstants.Email, MailConstants.Password);
                await smtp.SendAsync(email);

                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

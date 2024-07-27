using KormosalaWebApi.Application.Abstractions.Services.MailServices;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Infrastructure.Services.MailServices
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] {to}, subject,body);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            foreach (var to in tos)
            {
                mailMessage.To.Add(to);
            }

            mailMessage.Body = body;
            mailMessage.From = new MailAddress("nina.howe35@ethereal.email", "MavxsZSfeEqZZ6xXJb", System.Text.Encoding.UTF8);

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("nina.howe35@ethereal.email", "MavxsZSfeEqZZ6xXJb");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.ethereal.email";

            await smtp.SendMailAsync(mailMessage);
        }

        public async Task SendPasswordResetMailAsync(string to, int userId, string resetToken)
        {
            StringBuilder mail = new StringBuilder();
            mail.AppendLine("Hello</br></br> If you have requested a new password, you can renew your password from the link below. </br> <strong><a target = \"_blank\" href =\"");
            mail.AppendLine(_configuration["ClientUiUrl"]);
            mail.AppendLine("/update-password");
            mail.AppendLine(userId.ToString());
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine($"\"> Click for new password... </a></strong>");

            await SendMailAsync(to,"Password Reset", mail.ToString());
        }
    }
}

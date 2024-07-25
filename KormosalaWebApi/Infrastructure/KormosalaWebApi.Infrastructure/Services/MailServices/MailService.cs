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

        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] {to}, subject,body);
        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
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
    }
}

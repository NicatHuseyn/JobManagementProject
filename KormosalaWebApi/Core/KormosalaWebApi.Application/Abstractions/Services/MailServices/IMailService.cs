using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Abstractions.Services.MailServices
{
    public interface IMailService
    {
        Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true);
        Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Application.Exceptions
{
    public class PasswordChangeFIeldException : Exception
    {
        public PasswordChangeFIeldException():base("Sifre yenilenerken problem yarandi")
        {
        }

        public PasswordChangeFIeldException(string? message) : base(message)
        {
        }

        public PasswordChangeFIeldException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

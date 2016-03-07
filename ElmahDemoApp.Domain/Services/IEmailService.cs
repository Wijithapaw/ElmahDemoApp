using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);

        void Send(MailMessage email);
    }
}

using Shop.ApplicationCore.Interfaces;
using Shop.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class EmailSenderService :  IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Закладная для логики отправки сообщений по электронной почте
            return Task.CompletedTask;
        }
    }
}

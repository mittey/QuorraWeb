using System.Threading.Tasks;

namespace QuorraWeb.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

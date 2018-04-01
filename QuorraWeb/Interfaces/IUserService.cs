using System.Threading.Tasks;
using QuorraWeb.Models;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IUserService
    {
        Task HandleUserAsync(Message message);
        Task<ApplicationUser> SaveTelegramUsernameAsync(string telegramUsername, string userId);
    }
}

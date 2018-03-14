using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IUserService
    {
        Task HandleUserAsync(Message message);
    }
}

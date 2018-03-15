using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IJokeService
    {
        Task HandleJokeAsync(Message message);
    }
}

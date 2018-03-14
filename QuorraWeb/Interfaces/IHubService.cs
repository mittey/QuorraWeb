using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IHubService
    {
        Task HandleMessageAsync(Message message);
    }
}

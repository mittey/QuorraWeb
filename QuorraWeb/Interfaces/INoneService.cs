using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface INoneService
    {
        Task HandleNoneAsync(Message message);
    }
}

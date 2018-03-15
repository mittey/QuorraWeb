using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IMemeService
    {
        Task HandleMemeAsync(Message message);
    }
}
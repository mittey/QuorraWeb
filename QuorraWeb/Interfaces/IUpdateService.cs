using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace QuorraWeb.Interfaces
{
    public interface IUpdateService
    {
        Task<Message> ReceiveUpdate(Update update);
    }
}

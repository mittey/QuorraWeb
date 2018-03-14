using System.Threading.Tasks;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace QuorraWeb.Services
{
    public class UpdateService : IUpdateService
    {
        public Task<Message> ReceiveUpdate(Update update)
        {
            if (update.Type != UpdateType.MessageUpdate)
            {
                return null;
            }

            return Task.FromResult(update.Message);
        }
    }
}

using System.Threading.Tasks;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;

namespace QuorraWeb.Services
{
    public class NoneService : INoneService
    {
        private readonly IBotService _botService;

        public NoneService(IBotService botService)
        {
            _botService = botService;
        }

        public async Task HandleNoneAsync(Message message)
        {
            await TellNoneAsync(message);
        }

        private async Task TellNoneAsync(Message message)
        {
            await _botService.TelegramBotClient.SendTextMessageAsync(message.Chat.Id, "I’m sorry, I didn’t catch what you said. I need to learn more.");
        }
    }
}

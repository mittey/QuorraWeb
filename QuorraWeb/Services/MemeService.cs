using System.Threading.Tasks;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;

namespace QuorraWeb.Services
{
    public class MemeService : IMemeService
    {
        private readonly IBotService _botService;

        public MemeService(IBotService botService)
        {
            _botService = botService;
        }

        public async Task HandleMemeAsync(Message message)
        {
            await SendMeme(message);
        }

        private async Task SendMeme(Message message)
        {
            await _botService.TelegramBotClient.SendTextMessageAsync(message.Chat.Id, "There will be a meme here.");
        }
    }
}
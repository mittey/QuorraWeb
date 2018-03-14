using Telegram.Bot;

namespace QuorraWeb.Interfaces
{
    public interface IBotService
    {
        TelegramBotClient TelegramBotClient { get; }
    }
}

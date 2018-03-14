using Microsoft.Extensions.Options;
using QuorraWeb.Interfaces;
using QuorraWeb.Models.Configs;
using Telegram.Bot;

namespace QuorraWeb.Services
{
    public class BotService : IBotService
    {
        private static IOptions<BotConfiguration> _options;

        public BotService(IOptions<BotConfiguration> options)
        {
            _options = options;

            TelegramBotClient = new TelegramBotClient(_options.Value.BotApiKey);
        }

        public TelegramBotClient TelegramBotClient { get; }
    }
}

using System.Threading.Tasks;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace QuorraWeb.Services
{
    public class HubService : IHubService
    {
        public HubService()
        {

        }

        public async Task HandleMessageAsync(Message message)
        {
            if (message.Type == MessageType.TextMessage)
            {
                await HandleTextMessageAsync(message);
            }

            if (message.Type == MessageType.VoiceMessage)
            {
                await HandleVoiceMessageAsync(message);
            }
        }

        private async Task HandleTextMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }

        private async Task HandleVoiceMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}

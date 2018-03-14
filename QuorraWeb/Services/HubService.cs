using System.Threading.Tasks;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace QuorraWeb.Services
{
    public class HubService : IHubService
    {
        private readonly IUserService _userService;
        private readonly INoneService _noneService;

        public HubService(IUserService userService, INoneService noneService)
        {
            _userService = userService;
            _noneService = noneService;
        }

        public async Task HandleMessageAsync(Message message)
        {
            await _userService.HandleUserAsync(message);

            switch (message.Type)
            {
                case MessageType.TextMessage:
                    await HandleTextMessageAsync(message);
                    break;
                case MessageType.VoiceMessage:
                    await HandleVoiceMessageAsync(message);
                    break;
            }
        }

        private async Task HandleTextMessageAsync(Message message)
        {
            await _noneService.HandleNoneAsync(message);
        }

        private async Task HandleVoiceMessageAsync(Message message)
        {
            await _noneService.HandleNoneAsync(message);
        }
    }
}

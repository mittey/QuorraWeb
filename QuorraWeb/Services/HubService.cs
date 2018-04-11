using System.Linq;
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
        private readonly ILuisService _luisService;
        private readonly IJokeService _jokeService;
        private readonly IMemeService _memeService;
        private readonly IMusicService _musicService;

        public HubService(IUserService userService, INoneService noneService, ILuisService luisService, IJokeService jokeService, IMemeService memeService, IMusicService musicService)
        {
            _userService = userService;
            _noneService = noneService;
            _luisService = luisService;
            _jokeService = jokeService;
            _memeService = memeService;
            _musicService = musicService;
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
            var luisData = await _luisService.GetAllDataAsync(message.Text);

            switch (luisData.TopScoringIntent.Intent)
            {
                case "Joke.Show":
                    await _jokeService.HandleJokeAsync(message);
                    break;
                case "Meme.Show":
                    await _memeService.HandleMemeAsync(message);
                    break;
                case "Music.PlayMusic":
                    if (luisData.Entities.Any())
                    {
                        var query = luisData.Entities.FirstOrDefault()?.Entity;
                        await _musicService.HandleQueryAsync(query);
                    }

                    break;
                default:
                    await _noneService.HandleNoneAsync(message);
                    break;
            }
        }

        private async Task HandleVoiceMessageAsync(Message message)
        {
            await _noneService.HandleNoneAsync(message);
        }
    }
}

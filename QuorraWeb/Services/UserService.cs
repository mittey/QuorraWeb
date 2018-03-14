using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuorraWeb.Data;
using QuorraWeb.Interfaces;
using QuorraWeb.Models.Enums;
using Telegram.Bot.Types;

namespace QuorraWeb.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBotService _botService;

        public UserService(ApplicationDbContext context, IBotService botService)
        {
            _context = context;
            _botService = botService;
        }

        public async Task HandleUserAsync(Message message)
        {
            if (!await UserExistsAsync(message.Chat.Username))
            {
                await _botService.TelegramBotClient.SendTextMessageAsync(message.Chat.Id, $"{message.Chat.Username}, my apologies, but I don't believe we've met. Before we proceed further, please contact someone from Sopra Steria Saint Petersburg. Thank you.");
            }
        }

        private async Task<bool> UserExistsAsync(string telegramUsername)
        {
            return await _context.Users.AnyAsync(m => m.TelegramUsername == telegramUsername && m.Status == UserStatus.Active);
        }
    }
}

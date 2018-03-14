using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuorraWeb.Interfaces;
using Telegram.Bot.Types;

namespace QuorraWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Update")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        private readonly IHubService _hubService;

        public UpdateController(IUpdateService updateService, IHubService hubService)
        {
            _updateService = updateService;
            _hubService = hubService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            var message = await _updateService.ReceiveUpdate(update);
            await _hubService.HandleMessageAsync(message);

            return Ok();
        }
    }
}
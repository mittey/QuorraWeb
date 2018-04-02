using System.ComponentModel.DataAnnotations;

namespace QuorraWeb.Models.ManageViewModels
{
    public class TelegramViewModel
    {
        [Required]
        public string TelegramUsername { get; set; }

        public string StatusMessage { get; set; }
    }
}

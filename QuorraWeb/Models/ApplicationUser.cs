using System;
using Microsoft.AspNetCore.Identity;
using QuorraWeb.Models.Enums;

namespace QuorraWeb.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime RegesteredAt { get; set; } = DateTime.UtcNow;
        public UserStatus Status { get; set; } = UserStatus.Inactive;
        public string TelegramUsername { get; set; }
    }
}

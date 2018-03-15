using System.Threading.Tasks;
using QuorraWeb.Models.JSON;

namespace QuorraWeb.Interfaces
{
    public interface ILuisService
    {
        Task<string> GetTopScoringIntentAsync(string query);
        Task<RootObjectLuis> GetAllDataAsync(string query);
    }
}

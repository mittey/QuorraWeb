using System.Threading.Tasks;

namespace QuorraWeb.Interfaces
{
    public interface IMusicService
    {
        Task HandleQueryAsync(string query);
    }
}
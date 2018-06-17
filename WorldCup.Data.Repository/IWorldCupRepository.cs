using System.Threading.Tasks;
using WorldCup.UI.Models;

namespace WorldCup.Data.Repository
{
    public interface IWorldCupRepository
    {
        Task<Team[]> GetTeamsAsync();
    }
}

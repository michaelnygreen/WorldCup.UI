using System;
using System.Threading.Tasks;
using WorldCup.UI.Models;

namespace WorldCup.Data.Repository
{
    public interface IWorldCupRepository
    {
        Task<Team[]> GetTeamsAsync();

        Task<Player> AddPlayerAsync(Player player);
        Task<Player> SavePlayerAsync(Player player);
        Task DeletePlayerAsync(Guid playerId);
    }
}

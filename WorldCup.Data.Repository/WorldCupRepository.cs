using System;
using System.Threading.Tasks;
using WorldCup.UI.Models;

namespace WorldCup.Data.Repository
{
    public class WorldCupRepository : IWorldCupRepository
    {
        public Task<Team[]> GetTeamsAsync()
        {
            return Task.FromResult(new[]
            {
                new Team
                {
                    Id = Guid.NewGuid(),
                    Name = "Denmark",
                    Group = "C",
                    Players = new Player[0]
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    Name = "France",
                    Group = "C",
                    Players = new Player[0]
                }
            });
        }
    }
}

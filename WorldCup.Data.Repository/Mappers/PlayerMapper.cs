using System.Collections.Generic;
using System.Linq;
using Dto = WorldCup.Api.Dto;
using Service = WorldCup.UI.Models;

namespace WorldCup.Data.Repository.Mappers
{
    static class PlayerMapper
    {
        public static Service.Player[] Map(IEnumerable<Dto.Player> players)
        {
            return players.Select(Map).ToArray();
        }

        public static Service.Player Map(Dto.Player player)
        {
            return new Service.Player
            {
                Id = player.Id,
                Name = player.Name,
                DateOfBirth = player.DateOfBirth,
                Club = player.Club,
                Position = PositionMapper.Map(player.Position),
                SquadNumber = player.SquadNumber,
                TeamId = player.TeamId
            };
        }

        public static Dto.Player[] Map(IEnumerable<Service.Player> players)
        {
            return players.Select(Map).ToArray();
        }

        public static Dto.Player Map(Service.Player player)
        {
            return new Dto.Player
            {
                Id = player.Id,
                Name = player.Name,
                DateOfBirth = player.DateOfBirth,
                Club = player.Club,
                Position = PositionMapper.Map(player.Position),
                SquadNumber = player.SquadNumber,
                TeamId = player.TeamId
            };
        }
    }
}

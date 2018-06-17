using System.Collections.Generic;
using System.Linq;
using Dto = WorldCup.Api.Dto;
using Service = WorldCup.UI.Models;

namespace WorldCup.Data.Repository.Mappers
{
    static class TeamMapper
    {
        public static Service.Team[] Map(IEnumerable<Dto.Team> teams)
        {
            return teams.Select(Map).ToArray();
        }

        public static Service.Team Map(Dto.Team team)
        {
            return new Service.Team
            {
                Id = team.Id,
                Name = team.Name,
                Group = team.Group,
                Players = PlayerMapper.Map(team.Players)
            };
        }
    }
}

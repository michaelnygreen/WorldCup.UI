using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WorldCup.Data.Repository.Mappers;
using WorldCup.UI.Models;
using Dto = WorldCup.Api.Dto;

namespace WorldCup.Data.Repository
{
    public class WorldCupRepository : IWorldCupRepository
    {
        private readonly HttpClient _httpClient;

        public WorldCupRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Team[]> GetTeamsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("v1/teams");
            Dto.Team[] teams = await response.Content.ReadAsAsync<Dto.Team[]>();
            return TeamMapper.Map(teams);
        }

        public async Task<Player> AddPlayerAsync(Player player)
        {
            Dto.Player dtoPlayer = PlayerMapper.Map(player);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("v1/players", dtoPlayer);
            Dto.Player responsePlayer = await response.Content.ReadAsAsync<Dto.Player>();
            return PlayerMapper.Map(responsePlayer);
        }

        public async Task DeletePlayerAsync(Guid playerId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"v1/players/{playerId}");
            string result = await response.Content.ReadAsStringAsync();
        }

        public async Task<Player> SavePlayerAsync(Player player)
        {
            Dto.Player dtoPlayer = PlayerMapper.Map(player);
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("v1/players", dtoPlayer);
            Dto.Player responsePlayer = await response.Content.ReadAsAsync<Dto.Player>();
            return PlayerMapper.Map(responsePlayer);
        }
    }
}

using Newtonsoft.Json;
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
            var jsonString = await _httpClient.GetStringAsync("v1/teams");
            var teams = JsonConvert.DeserializeObject<Dto.Team[]>(jsonString);
            return TeamMapper.Map(teams);
        }
    }
}

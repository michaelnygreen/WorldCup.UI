using System;
using System.Collections.ObjectModel;
using System.Linq;
using WorldCup.Data.Repository;
using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class TeamViewModel
    {
        private readonly IWorldCupRepository _worldCupRepository;
        private readonly Team _team;

        public TeamViewModel(Team team, IWorldCupRepository worldCupRepository)
        {
            _worldCupRepository = worldCupRepository;
            _team = team;
            Players = new ObservableCollection<PlayerViewModel>(team.Players.Select(p => new PlayerViewModel(p, team, _worldCupRepository)));
        }

        public Guid Id { get => _team.Id; }
        public string Name { get => _team.Name; }
        public string Group { get => _team.Group; }
        public ObservableCollection<PlayerViewModel> Players { get; }

        public PlayerViewModel AddPlayer(Player player)
        {
            PlayerViewModel viewModel = new PlayerViewModel(player, _team, _worldCupRepository);
            Players.Add(viewModel);
            return viewModel;
        }

        public void DeletePlayer(PlayerViewModel player)
        {
            Players.Remove(player);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

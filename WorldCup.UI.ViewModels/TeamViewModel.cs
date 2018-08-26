using System.Collections.ObjectModel;
using System.Linq;
using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class TeamViewModel
    {
        private readonly Team _team;

        public TeamViewModel(Team team)
        {
            _team = team;
            Players = new ObservableCollection<PlayerViewModel>(team.Players.Select(p => new PlayerViewModel(p)));
        }

        public string Name { get => _team.Name; }
        public string Group { get => _team.Group; }
        public ObservableCollection<PlayerViewModel> Players { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}

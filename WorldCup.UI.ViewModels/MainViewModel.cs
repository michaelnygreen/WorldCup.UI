using System.Collections.ObjectModel;
using System.Linq;
using WorldCup.Data.Repository;

namespace WorldCup.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IWorldCupRepository _worldCupRepository;

        private TeamViewModel _selectedTeam;
        private PlayerViewModel _selectedPlayer;

        public MainViewModel(IWorldCupRepository worldCupRepository)
        {
            _worldCupRepository = worldCupRepository;

            Teams = new ObservableCollection<TeamViewModel>(_worldCupRepository.GetTeamsAsync().Result.Select(t => new TeamViewModel(t)));
        }

        public ObservableCollection<TeamViewModel> Teams { get; }

        public TeamViewModel SelectedTeam
        {
            get => _selectedTeam;
            set => SetProperty(ref _selectedTeam, value);
        }

        public PlayerViewModel SelectedPlayer
        {
            get => _selectedPlayer;
            set => SetProperty(ref _selectedPlayer, value);
        }
    }
}

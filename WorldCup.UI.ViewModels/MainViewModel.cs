using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WorldCup.Data.Repository;

namespace WorldCup.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _teamsLoaded;
        private readonly IWorldCupRepository _worldCupRepository;

        private ObservableCollection<TeamViewModel> _teams = new ObservableCollection<TeamViewModel>();
        private TeamViewModel _selectedTeam;
        private PlayerViewModel _selectedPlayer;

        public MainViewModel(IWorldCupRepository worldCupRepository)
        {
            _worldCupRepository = worldCupRepository;
        }

        public ObservableCollection<TeamViewModel> Teams
        {
            get
            {
                if (!_teamsLoaded) LoadTeamsAsync();
                return _teams;
            }

            private set
            {
                SetProperty(ref _teams, value);
            }
        }

        private async void LoadTeamsAsync()
        {
            var teams = await _worldCupRepository.GetTeamsAsync();
            var newTeams = new ObservableCollection<TeamViewModel>(teams.Select(t => new TeamViewModel(t)));
            _teamsLoaded = true;
            Teams = newTeams;
        }

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

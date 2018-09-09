using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldCup.Data.Repository;
using WorldCup.UI.Models;
using WorldCup.UI.ViewModels.Commands;

namespace WorldCup.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool _teamsLoaded;
        private readonly IWorldCupRepository _worldCupRepository;

        private ObservableCollection<TeamViewModel> _teams = new ObservableCollection<TeamViewModel>();
        private TeamViewModel _selectedTeam;
        private PlayerViewModel _selectedPlayer;

        private RelayCommand _addPlayerCommand;
        private RelayCommand _deletePlayerCommand;

        public MainViewModel(IWorldCupRepository worldCupRepository)
        {
            _worldCupRepository = worldCupRepository;

            _addPlayerCommand = new RelayCommand(AddPlayer, () => SelectedTeam != null);
            _deletePlayerCommand = new RelayCommand(DeletePlayer, () => SelectedPlayer != null);
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
            var newTeams = new ObservableCollection<TeamViewModel>(teams.Select(t => new TeamViewModel(t, _worldCupRepository)));
            _teamsLoaded = true;
            Teams = newTeams;
        }

        public TeamViewModel SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                SetProperty(ref _selectedTeam, value);
                _addPlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public PlayerViewModel SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                SetProperty(ref _selectedPlayer, value);
                _deletePlayerCommand.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddPlayerCommand => _addPlayerCommand;
        public ICommand DeletePlayerCommand => _deletePlayerCommand;

        public async Task AddPlayer()
        {
            Player newPlayer = new Player
            {
                Id = Guid.NewGuid(),
                Name = "New Player",
                TeamId = SelectedTeam.Id
            };

            await _worldCupRepository.AddPlayerAsync(newPlayer);
            SelectedPlayer = SelectedTeam.AddPlayer(newPlayer);
        }

        public async Task DeletePlayer()
        {
            await _worldCupRepository.DeletePlayerAsync(SelectedPlayer.Id);

            SelectedTeam.DeletePlayer(SelectedPlayer);
            SelectedPlayer = null;
        }

        public Position[] Positions => new [] { Position.Goalkeeper, Position.Defender, Position.Midfielder, Position.Forward };
    }
}

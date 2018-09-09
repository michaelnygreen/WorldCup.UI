using System;
using System.Threading.Tasks;
using WorldCup.Data.Repository;
using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class PlayerViewModel : ModifiableViewModel
    {
        private readonly IWorldCupRepository _worldCupRepository;

        private readonly Player _player;

        private string _name;
        private string _club;
        private DateTime _dateOfBirth;
        private Position _position;
        private int _squadNumber;

        public PlayerViewModel(Player player, IWorldCupRepository worldCupRepository)
        {
            _worldCupRepository = worldCupRepository;
            _player = player;

            Reset();
        }

        public Guid Id => _player.Id;

        public string Name
        {
            get => _name;
            set => ModifyProperty(ref _name, value);
        }

        public string Club
        {
            get => _club;
            set => ModifyProperty(ref _club, value);
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => ModifyProperty(ref _dateOfBirth, value);
        }

        public Position Position
        {
            get => _position;
            set => ModifyProperty(ref _position, value);
        }

        public int SquadNumber
        {
            get => _squadNumber;
            set => ModifyProperty(ref _squadNumber, value);
        }

        protected override Task Reset()
        {
            _name = _player.Name;
            _club = _player.Club;
            _dateOfBirth = _player.DateOfBirth;
            _position = _player.Position;
            _squadNumber = _player.SquadNumber;

            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Club));
            RaisePropertyChanged(nameof(DateOfBirth));
            RaisePropertyChanged(nameof(Position));
            RaisePropertyChanged(nameof(SquadNumber));

            IsModified = false;

            return Task.CompletedTask;
        }

        protected override async Task Save()
        {
            _player.Name = _name;
            _player.Club = _club;
            _player.DateOfBirth = _dateOfBirth;
            _player.Position = _position;
            _player.SquadNumber = _squadNumber;

            await _worldCupRepository.SavePlayerAsync(_player);

            IsModified = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

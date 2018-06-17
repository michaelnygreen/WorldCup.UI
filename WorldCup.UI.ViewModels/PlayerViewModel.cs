using System;
using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class PlayerViewModel
    {
        private readonly Player _player;

        public PlayerViewModel(Player player)
        {
            _player = player;
        }

        public string Name { get => _player.Name; }
        public string Club { get => _player.Club; }
        public DateTime DateOfBirth { get => _player.DateOfBirth; }
        public Position Position { get => _player.Position; }
        public int SquadNumber { get => _player.SquadNumber; }

        public override string ToString()
        {
            return Name;
        }
    }
}

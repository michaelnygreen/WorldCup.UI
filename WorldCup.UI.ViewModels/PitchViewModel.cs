using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class PitchViewModel : BaseViewModel
    {
        private Position _position;
        private int _squadNumber;
        private string _country;

        public PitchViewModel()
        {
        }

        public Position Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        public int SquadNumber
        {
            get => _squadNumber;
            set => SetProperty(ref _squadNumber, value);
        }

        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}

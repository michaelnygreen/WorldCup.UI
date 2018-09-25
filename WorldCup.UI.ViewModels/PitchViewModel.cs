using WorldCup.UI.Models;

namespace WorldCup.UI.ViewModels
{
    public class PitchViewModel : BaseViewModel
    {
        private Position _position;

        private string _pitchPosition;
        private string _foreground;
        private string _background;

        public PitchViewModel()
        {
            Foreground = "Red";
            Background = "White";
        }

        public Position Position
        {
            get => _position;
            set
            {
                if (SetProperty(ref _position, value))
                {
                    switch (_position)
                    {
                        case Position.Goalkeeper:
                            PitchPosition = "50,10";
                            break;

                        case Position.Defender:
                            PitchPosition = "50,30";
                            break;

                        case Position.Midfielder:
                            PitchPosition = "50,65";
                            break;

                        case Position.Forward:
                            PitchPosition = "50,95";
                            break;
                    }
                }
            }
        }

        public string PitchPosition
        {
            get => _pitchPosition;
            set => SetProperty(ref _pitchPosition, value);
        }

        public string Foreground
        {
            get => _foreground;
            set => SetProperty(ref _foreground, value);
        }

        public string Background
        {
            get => _background;
            set => SetProperty(ref _background, value);
        }
    }
}

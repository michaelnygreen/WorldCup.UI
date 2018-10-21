using System.Windows;
using System.Windows.Controls;
using WorldCup.UI.CustomControls.Enums;

namespace WorldCup.UI.CustomControls.Panels
{
    public class PitchPositionPanel : Panel
    {
        public static readonly DependencyProperty PitchPositionProperty =
            DependencyProperty.RegisterAttached("PitchPosition", typeof(PitchPosition), typeof(PitchPosition), new FrameworkPropertyMetadata(PitchPosition.Unknown, FrameworkPropertyMetadataOptions.AffectsParentArrange));

        [AttachedPropertyBrowsableForChildren]
        public static PitchPosition GetPitchPosition(DependencyObject obj)
        {
            return (PitchPosition)obj.GetValue(PitchPositionProperty);
        }

        [AttachedPropertyBrowsableForChildren]
        public static void SetPitchPosition(DependencyObject obj, PitchPosition value)
        {
            obj.SetValue(PitchPositionProperty, value);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size availablePlayerSize = CalculatePlayerSize(availableSize);

            foreach (UIElement child in Children)
            {
                child.Measure(availablePlayerSize);
            }

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size playerSize = CalculatePlayerSize(finalSize);
            double horizontalPosition = CalculateHorizontalPosition(finalSize, playerSize.Width);

            foreach (UIElement child in Children)
            {
                PitchPosition position = GetPitchPosition(child);
                double verticalPosition = CalculateVerticalPosition(finalSize, position);
                Point playerPosition = new Point(horizontalPosition, verticalPosition);
                child.Arrange(new Rect(playerPosition, playerSize));
            }

            return base.ArrangeOverride(finalSize);
        }

        private Size CalculatePlayerSize(Size pitchSize)
        {
            double pitchWidth = pitchSize.Width == double.NaN ? 1000 : pitchSize.Width;
            double playerWidthAndHeight = pitchWidth / 15;

            return new Size(playerWidthAndHeight, playerWidthAndHeight);
        }

        private double CalculateHorizontalPosition(Size pitchSize, double playerWidth)
        {
            double pitchWidth = pitchSize.Width == double.NaN ? 1000 : pitchSize.Width;
            return (pitchWidth - playerWidth) / 2;
        }

        private double CalculateVerticalPosition(Size pitchSize, PitchPosition pitchPosition)
        {
            double pitchHeight = pitchSize.Height == double.NaN ? 1000 : pitchSize.Height;
            switch (pitchPosition)
            {
                case PitchPosition.Goalkeeper:
                    return pitchHeight * 0.05;

                case PitchPosition.Defender:
                    return pitchHeight * 0.25;

                case PitchPosition.Midfielder:
                    return pitchHeight * 0.50;

                case PitchPosition.Forward:
                    return pitchHeight * 0.75;

                case PitchPosition.Unknown:
                default:
                    return 0;
            }
        }
    }
}

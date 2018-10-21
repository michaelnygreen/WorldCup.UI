using System.Windows;
using System.Windows.Controls;

namespace WorldCup.UI.CustomControls.Controls
{
    public class PitchControl : ContentControl
    {
        private static double RequiredAspectRatio = 130.0 / 100;

        static PitchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PitchControl), new FrameworkPropertyMetadata(typeof(PitchControl)));
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (constraint.Height != double.NaN && constraint.Width != double.NaN && constraint.Height > 0 && constraint.Width > 0)
            {
                return CalculateSize(constraint);
            }

            return base.MeasureOverride(constraint);
        }

        private Size CalculateSize(Size size)
        {
            double aspectRatio = size.Height / size.Width;
            if (aspectRatio > RequiredAspectRatio)
            {
                return new Size(size.Width, size.Width * RequiredAspectRatio);
            }
            else if (aspectRatio < RequiredAspectRatio)
            {
                return new Size(size.Height / RequiredAspectRatio, size.Height);
            }

            return size;
        }
    }
}

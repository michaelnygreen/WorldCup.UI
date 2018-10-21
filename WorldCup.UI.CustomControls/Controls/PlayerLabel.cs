using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WorldCup.UI.CustomControls.Controls
{
    public class PlayerLabel : Label
    {
        public static readonly DependencyProperty BackgroundImageProperty =
            DependencyProperty.Register("BackgroundImage", typeof(ImageSource), typeof(PlayerLabel), new PropertyMetadata(null));

        static PlayerLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayerLabel), new FrameworkPropertyMetadata(typeof(PlayerLabel)));
        }

        public ImageSource BackgroundImage
        {
            get { return (ImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
    }
}

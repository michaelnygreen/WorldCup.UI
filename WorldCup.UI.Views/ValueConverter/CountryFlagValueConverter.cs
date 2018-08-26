using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WorldCup.UI.Views.ValueConverter
{
    class CountryFlagValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("The target must be an Image Source!");

            string teamName = value as string;
            if (teamName == null)
                throw new InvalidOperationException("The value must be a string!");

            string flagUri = $"Images/Flags/{teamName.ToLower().Replace(' ', '-')}.png";
            return new BitmapImage(new Uri(flagUri, UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

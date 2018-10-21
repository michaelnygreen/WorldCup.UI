using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using WorldCup.UI.CustomControls.Enums;
using WorldCup.UI.Models;

namespace WorldCup.UI.Views.ValueConverter
{
    class PositionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Position) value)
            {
                case Position.Goalkeeper:
                    return "GK";

                case Position.Defender:
                    return "D";

                case Position.Midfielder:
                    return "M";

                case Position.Forward:
                    return "F";

                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    class PositionToPitchPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Position)value)
            {
                case Position.Goalkeeper:
                    return PitchPosition.Goalkeeper;

                case Position.Defender:
                    return PitchPosition.Defender;

                case Position.Midfielder:
                    return PitchPosition.Midfielder;

                case Position.Forward:
                    return PitchPosition.Forward;

                default:
                    return PitchPosition.Unknown;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

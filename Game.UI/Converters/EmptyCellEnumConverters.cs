using System;
using System.Globalization;
using System.Windows.Data;
using Game.Core.Enums;

namespace Game.UI.Converters
{
    internal class EmptyCellEnumConverters : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(targetType != typeof(string))
            {
                throw new InvalidOperationException("The target must be a string.");
            }

            return value.ToString().Equals(Player.Unknown.ToString()) ? string.Empty : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

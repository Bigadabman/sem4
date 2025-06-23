using System;
using System.Globalization;
using System.Windows.Data;

namespace LibraryApp
{
    public class NullToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует null в false, не-null в true.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        /// <summary>
        /// Не используется (обратное преобразование не требуется).
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
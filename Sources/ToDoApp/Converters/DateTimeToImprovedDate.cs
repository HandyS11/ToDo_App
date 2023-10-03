using System.Globalization;

namespace ToDoApp.Converters
{
    public class DateTimeToImprovedDate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "N/A";
            return ((DateTime)value).ToString("dd MMM yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

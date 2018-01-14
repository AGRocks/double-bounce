using System;
using System.Globalization;
using Xamarin.Forms;

namespace traininghub.mobile.Converters
{
    public class TimeSpanToTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var timeSpan = (TimeSpan)value;
            var dateTime = DateTime.MinValue + timeSpan;
            DateTimeFormatInfo dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            string shortTimePattern = dateTimeFormat.LongTimePattern.Replace(":ss", String.Empty).Replace(":s", String.Empty);
            return dateTime.ToString(shortTimePattern);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException("TimeSpanToTimeStringConverter.ConvertBack");
        }

    }
}

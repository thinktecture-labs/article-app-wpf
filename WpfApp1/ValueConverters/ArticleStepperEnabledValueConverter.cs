using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Models;

namespace WpfApp1.ValueConverters
{
    public class ArticleStepperEnabledValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var next = (string)parameter == "Next";
            var article = (Article)value;

            return next ? article?.NextId != null : article?.PreviousId != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

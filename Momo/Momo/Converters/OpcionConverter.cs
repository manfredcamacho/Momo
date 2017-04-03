using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Momo.Models;
using Momo.Pages;

namespace Momo.Converters
{
    public class OpcionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Dictionary<Idiomas, string>)value)[(PreguntaPage.Idioma)];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

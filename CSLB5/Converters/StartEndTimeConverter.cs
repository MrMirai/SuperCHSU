using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using MVVM.Converters;

namespace CSLB5.Converters;

public class StartEndTimeConverter : MarkupExtension, IMultiValueConverter
{

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var time1 = TimeOnly.FromDateTime((DateTime) values[0]);
        var time2 = TimeOnly.FromDateTime((DateTime) values[1]);
        return $"{time1} - {time2}";
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #region MarkupExtension members

    public sealed override object ProvideValue(IServiceProvider serviceProvider) => Converter;
    private static readonly StartEndTimeConverter Converter = new();

    #endregion
}
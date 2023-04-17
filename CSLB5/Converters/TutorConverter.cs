using System;
using System.Globalization;
using CSLB5.DataBase.Entities;
using MVVM.Converters;

namespace CSLB5.Converters;

public class TutorConverter : ConverterBase<TutorConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Tutor tutor
            ? $"{tutor.Surname} {tutor.Name} {tutor.Patronimic}"
            : "Ошибка: неверный формат";
    }
}
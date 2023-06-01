using System;
using System.Globalization;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.Converters;

namespace SuperCHSU.MainModule.Converters;

public class TutorConverter : ConverterBase<TutorConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Tutor tutor
            ? $"{tutor.Surname} {tutor.Name} {tutor.Patronimic}"
            : "Ошибка: неверный формат";
    }
}
using SuperCHSU.MainModule.Resources;
using SuperCHSU.MainModule.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCHSU.MainModule.Converters
{
    internal class WeekdayConverter : ConverterBase<WeekdayConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is DateTime date
                ? $"{ListOfWeekdays.weekdays[((int)date.DayOfWeek)]} / {date.ToString("dd.MM.yyyy")}"
                : "Ошибка: неверный формат даты";
        }
    }
}

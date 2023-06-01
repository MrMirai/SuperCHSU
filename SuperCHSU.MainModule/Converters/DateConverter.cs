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
    internal class DateConverter: ConverterBase<DateConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is DateOnly date
                ? $"{date.Day} {ListOfMounths.mounths[date.Month - 1]} {date.Year}"
                : "Ошибка: неверный формат даты";
        }
    }
}

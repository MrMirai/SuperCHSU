using CSLB5.DataBase.Entities;
using MVVM.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLB5.Converters
{
    class TimeToPositionConverter : ConverterBase<TimeToPositionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = TimeOnly.FromDateTime((DateTime)value);
            //int XStart = (schedule.StartTime.Hour - 8) * 60 + schedule.StartTime.Minute;
            // Здесь вы можете настроить масштаб времени, например, 1 час = 40 пикселей
            return (time.Hour - 8) * 60 + time.Minute;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

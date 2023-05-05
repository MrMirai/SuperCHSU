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
    class TimeToDoubleConverter : MultiValueConverterBase<TimeToDoubleConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var time1 = TimeOnly.FromDateTime((DateTime)values[0]);
            var time2 = TimeOnly.FromDateTime((DateTime)values[1]);
            //int Width = (schedule.EndTime.Hour - schedule.StartTime.Hour) * 60 + (schedule.EndTime.Minute - schedule.StartTime.Minute);
            return (time2.Hour - time1.Hour) * 60 + (time2.Minute - time1.Minute);
        }
    }
}

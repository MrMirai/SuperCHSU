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
    class ClassroomConverter: ConverterBase<ClassroomConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Classroom classroom
                ? $"{classroom.Number}{classroom.Letter}"
                : "Ошибка: неверный формат";
        }
    }
}

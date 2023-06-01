using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCHSU.MainModule.Converters
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

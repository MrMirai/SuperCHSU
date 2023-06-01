using SuperCHSU.MainModule.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static SuperCHSU.MainModule.Resources.Extensions;

namespace SuperCHSU.MainModule.Converters
{
    internal class TypeOfLectureToColor : ConverterBase<TypeOfLectureToColor>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string) return new SolidColorBrush(Colors.Firebrick);
            if (value.ToString() == "л") return NumberBrushes[Resources.TypeOfLecturers.Lecture];
            if (value.ToString() == "лб") return NumberBrushes[Resources.TypeOfLecturers.LaboratoryWork];
            if (value.ToString() == "конс") return NumberBrushes[Resources.TypeOfLecturers.Consultation];
            if (value.ToString() == "п") return NumberBrushes[Resources.TypeOfLecturers.Practice];
            if (value.ToString() == "п.экз") return NumberBrushes[Resources.TypeOfLecturers.ExamRetake];
            if (value.ToString() == "экз") return NumberBrushes[Resources.TypeOfLecturers.Exam];
            return new SolidColorBrush(Colors.Green);
        }
    }
}

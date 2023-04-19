using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CSLB5.Resources
{
    internal class Extensions
    {

        public static readonly Dictionary<TypeOfLecturers, Brush> NumberBrushes= new()
    {
        { TypeOfLecturers.Lecture, new SolidColorBrush(Colors.Cornsilk) },
        { TypeOfLecturers.LaboratoryWork, new SolidColorBrush(Colors.MintCream) },
        { TypeOfLecturers.Practice, new SolidColorBrush(Colors.Honeydew)  },
        { TypeOfLecturers.Consultation, new SolidColorBrush(Colors.Lavender)  },
        { TypeOfLecturers.Exam, new SolidColorBrush(Colors.LavenderBlush)  },
        { TypeOfLecturers.ExamRetake, new SolidColorBrush(Colors.AliceBlue)  },
    };
    }
}

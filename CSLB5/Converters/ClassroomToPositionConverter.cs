using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MVVM.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLB5.Converters
{
    class ClassroomToPositionConverter : ConverterBase<ClassroomToPositionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IRepository<Classroom> repository = App.Services.GetRequiredService<IRepository<Classroom>>();
            var classroom = (Classroom)value;
            int classroomIndex = Array.IndexOf(repository.Items.ToArray(), classroom);
            // Здесь вы можете настроить высоту блока и расстояние между ними, например, высота блока = 30 пикселей, расстояние = 10 пикселей
            return (classroomIndex * 30);

        }
    }
}

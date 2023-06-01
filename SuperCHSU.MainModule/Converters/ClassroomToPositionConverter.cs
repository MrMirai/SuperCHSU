using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SuperCHSU.MainModule.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Unity;

namespace SuperCHSU.MainModule.Converters
{
    class ClassroomToPositionConverter : ConverterBase<ClassroomToPositionConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //IRepository<Classroom> repository = Container.Resolve<IRepository<Classroom>>();
            IContainerProvider container = new UnityContainerExtension();
            IRepository<Classroom> repository = container.Resolve<IRepository<Classroom>>();
            var classroom = (Classroom)value;
            int classroomIndex = Array.IndexOf(repository.Items.ToArray(), classroom);
            // Здесь вы можете настроить высоту блока и расстояние между ними, например, высота блока = 30 пикселей, расстояние = 10 пикселей
            return (classroomIndex * 30);

        }
    }
}

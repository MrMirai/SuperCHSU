using Azure.Core;
using CSLB5.DataBase.Entities;
using CSLB5.Resources;
using MVVM.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLB5.Converters
{
    internal class ScheduleToString : ConverterBase<ScheduleToString>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Schedule schedule
                ? $"Предмет: {schedule.Lecture.Name}\nАудитория: {schedule.Classroom.Number}\nВремя: {schedule.StartTime.ToString("HH:mm")}-{schedule.EndTime.ToString("HH:mm")}\nПреподаватель: {schedule.Tutor.Surname} {schedule.Tutor.Name} {schedule.Tutor.Patronimic}"
                : "Ошибка: неверные данные";
        }
    }
}

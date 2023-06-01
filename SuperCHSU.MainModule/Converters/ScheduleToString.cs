using Azure.Core;
using SuperCHSU.MainModule.DataBase.Entities;
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
    internal class ScheduleToString : ConverterBase<ScheduleToString>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Schedule schedule
                ? $"Предмет: {schedule.Lecture.Name}\nАудитория: {schedule.Classroom.Number}{schedule.Classroom.Letter}\nВремя: {schedule.StartTime.ToString("HH:mm")} - {schedule.EndTime.ToString("HH:mm")}\nПреподаватель: {schedule.Tutor.Surname} {schedule.Tutor.Name} {schedule.Tutor.Patronimic}"
                : "Ошибка: неверные данные";
        }
    }
}

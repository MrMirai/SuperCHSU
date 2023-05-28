using CSLB5.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CSLB5.Models
{
    public class ScheduleModel
    {
        //public ScheduleModel(DateOnly date)
        //{
        //    Date = date;
        //    Schedules = new List<Schedule>();
        //}

        //public DateOnly Date { get; set; }
        //public List<Schedule> Schedules { get; set; }
        public DateTime Date { get; set; }
        public List<Schedule> DataSchedule { get; set; }

        public ScheduleModel(DateTime date, List<Schedule> dataSchedule)
        {
            Date = date;
            DataSchedule = dataSchedule;
        }
    }
}

using CSLB5.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLB5.Models
{
    public class ScheduleModel
    {
        public DateOnly Date { get; set; }
        public ObservableCollection<Schedule> Data { get;set; }
 
        public ScheduleModel(DateOnly date, ObservableCollection<Schedule> data) { 
            Date = date;
            Data = data;
        }

    }
}

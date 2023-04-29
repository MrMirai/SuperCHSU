using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.Models;
using CSLB5.ViewModels.Base;
using MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Markup;

namespace CSLB5.ViewModels;

public class ReservationObserverGanttChartViewModel : BindableBase, IModel
{
    private readonly IRepository<Schedule>? _scheduleRepository;

    public ReservationObserverGanttChartViewModel(IRepository<Schedule>? scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        ObservableCollection<Schedule> _temp = new ObservableCollection<Schedule>();
        foreach (var item in _scheduleRepository.Items)
        {
           if (item.Data==new System.DateOnly(2023,4,14)) {
                _temp.Add(item);
           }
        }

        var groupedSchedules = _temp.GroupBy(x => x.Classroom.Number);
        foreach (var group in groupedSchedules)
        {
            _classrooms.Add(group.Key);
        }

        foreach (var item in _temp)
        {
            _rectangles.Add(ScheduleToRectangle(item));
        }      
    }

    private List<long> _classrooms = new List<long>();
    public List<long> Classrooms
    {
        get => _classrooms;
        set => SetProperty(ref _classrooms, value);
    }

    private List<RectangleModel> _rectangles = new List<RectangleModel>();
    public List<RectangleModel> Rectangles
    {
        get => _rectangles;
        set => SetProperty(ref _rectangles, value);
    }

    public RectangleModel ScheduleToRectangle(Schedule schedule)
    {
        int XStart = (schedule.StartTime.Hour-8)*60+schedule.StartTime.Minute;
        int Width = (schedule.EndTime.Hour - schedule.StartTime.Hour) * 60 + (schedule.EndTime.Minute - schedule.StartTime.Minute);
        int i = 0;
        foreach (var item in _classrooms)
        {
            if(item== schedule.Classroom.Number) break;
            i++;
        }
        int YStart = i*33;
        return new RectangleModel(XStart,YStart,Width);
    }
    public string Name => "Диаграмма Ганта";
}
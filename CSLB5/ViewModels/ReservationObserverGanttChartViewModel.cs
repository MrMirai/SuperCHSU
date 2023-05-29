using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.Models;
using CSLB5.ViewModels.Base;
using MVVM;
using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace CSLB5.ViewModels;

public class ReservationObserverGanttChartViewModel : BindableBase, IModel
{
    private readonly IRepository<Schedule>? _scheduleRepository;

    public ReservationObserverGanttChartViewModel(IRepository<Schedule>? scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        var groupedSchedules = _scheduleRepository.Items.ToList().GroupBy(x => x.Classroom);
        foreach (var group in groupedSchedules)
        {
            _classrooms.Add(group.Key);
        }
        foreach (var item in _scheduleRepository.Items)
        {
            _rectangles.Add(ScheduleToRectangle(item));
        }
        GetRectangleCommand = new RelayCommand(GetRectangle);
    }

    private List<Classroom> _classrooms = new List<Classroom>();
    public List<Classroom> Classrooms
    {
        get => _classrooms;
        set => SetProperty(ref _classrooms, value);
    }

    private DateTime _date=DateTime.Now;
    public DateTime Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
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
            if(item.ToString() == schedule.Classroom.ToString()) break;
            i++;
        }
        int YStart = i*30;
        return new RectangleModel(XStart,YStart,Width,schedule);
    }

    public ICommand GetRectangleCommand { get; set; }

    private void GetRectangle()
    {
        List<Classroom> tempClassrooms = new List<Classroom>();
        List<RectangleModel> tempRectangles= new List<RectangleModel>();
        var findDateSchedules = _scheduleRepository.Items.ToList().FindAll(x => x.Data == _date);
        var groupedSchedules = findDateSchedules.GroupBy(x => x.Classroom);
        foreach (var group in groupedSchedules)
        {
            tempClassrooms.Add(group.Key);
        }
        Classrooms = tempClassrooms;
        foreach (var group in groupedSchedules)
        {
            foreach (var item in group)
            {
                tempRectangles.Add(ScheduleToRectangle(item));
            }
        }
        GetRectangleCommand = new RelayCommand(GetRectangle);
        Rectangles = tempRectangles;
    }
    public string Name => "Диаграмма Ганта";
}
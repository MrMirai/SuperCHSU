using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.Models;
using CSLB5.ViewModels.Base;
using MVVM;
using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;


namespace CSLB5.ViewModels;

public class ReservationObserverGanttChartViewModel : BindableBase, IModel
{
    public string Name => "Диаграмма Ганта";
    private readonly IRepository<Schedule>? _scheduleRepository;
    private List<Classroom> _classrooms = new List<Classroom>();
    private DateTime _date = DateTime.Now;
    private List<RectangleModel> _rectangles = new List<RectangleModel>();


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

    
    public ICommand GetRectangleCommand { get; set; }

    public List<Classroom> Classrooms
    {
        get => _classrooms;
        set => SetProperty(ref _classrooms, value);
    }
    public DateTime Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }
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
}
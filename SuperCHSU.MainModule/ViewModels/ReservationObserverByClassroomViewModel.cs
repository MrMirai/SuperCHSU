using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.Models;
using SuperCHSU.MainModule.ViewModels.Base;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Prism.Commands;
using Prism.Regions;
using SuperCHSU.MainModule.DataBase.Context;
using SuperCHSU.MainModule.DataBase.Repositories;

namespace SuperCHSU.MainModule.ViewModels;

public class ReservationObserverByClassroomViewModel : BindableBase, IModel, INavigationAware
{
    public string Name => "Аудитории";
    private readonly IRepository<Schedule>? _scheduleRepository;
    public IRepository<Classroom> _classroomRepository { get; }
    private List<ScheduleModel> _data = new List<ScheduleModel>();
    private DateTime? _date;
    private ICollection<Classroom> _classroomCollection = new List<Classroom>();
    private Classroom _classroomSelected;
    private ICollection<ScheduleModel> _schedules = new List<ScheduleModel>();
    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    private CalendarSelectionMode _selectionMode = CalendarSelectionMode.SingleDate;
    public SelectedDatesCollection _dates;


    public ReservationObserverByClassroomViewModel(IRepository<Schedule> scheduleRepository, IRepository<Classroom> classroomRepository)
    {
        _scheduleRepository = scheduleRepository;
        _classroomRepository = classroomRepository;

        foreach (var item in _classroomRepository.Items.ToList())
        {
            ClassroomCollection.Add(item);
        }
        var groupedSchedules = _scheduleRepository.Items.ToList().GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            _data.Add(new ScheduleModel(group.Key, group.ToList()));
        }

        SetSelectModeToSingle = new DelegateCommand(OnSetSelectModeToSingle);
        SetSelectModeToRange = new DelegateCommand(OnSetSelectModeToRange);
        GetSheduleClassroomCommand = new DelegateCommand(GetSheduleClassroom);

    }

    public List<ScheduleModel> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }
    public DateTime? Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }
    public ICollection<Classroom> ClassroomCollection
    {
        get => _classroomCollection;
        set => SetProperty(ref _classroomCollection, value);
    }
    public Classroom ClassroomSelected
    {
        get => _classroomSelected;
        set => SetProperty(ref _classroomSelected, value);
    }
    public SelectedDatesCollection Dates
    {
        get => _dates;
        set => SetProperty(ref _dates, value);
    }
    public ICollection<ScheduleModel> Schedules
    {
        get => _schedules;
        set => SetProperty(ref _schedules, value);
    }
    public DateOnly Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    public CalendarSelectionMode SelectionMode
    {
        get => _selectionMode;
        set => SetProperty(ref _selectionMode, value);
    }


    public ICommand SetSelectModeToSingle { get; set; }

    private void OnSetSelectModeToSingle()
    {
        SelectionMode = CalendarSelectionMode.SingleDate;
    }
    public ICommand SetSelectModeToRange { get; set; }

    private void OnSetSelectModeToRange()
    {
        SelectionMode = CalendarSelectionMode.SingleRange;
    }
    public ICommand GetSheduleClassroomCommand { get; set; }

    private void GetSheduleClassroom()
    {
        if (ClassroomSelected != null)
        {
            if (SelectionMode == CalendarSelectionMode.SingleDate && _date != null)
            {
                List<ScheduleModel> newSchedules = new List<ScheduleModel>();
                var schedules = _scheduleRepository.Items.ToList().FindAll(x => x.Data == (DateTime)_date);

                List<Schedule> temp = new List<Schedule>();
                foreach (var schedule in schedules)
                {
                    if (ClassroomSelected.Id == schedule.ClassroomId) temp.Add(schedule);
                }
                newSchedules.Add(new ScheduleModel((DateTime)_date, temp));
                Data = newSchedules;
            }
            if (SelectionMode == CalendarSelectionMode.SingleRange && _dates != null)
            {
                List<ScheduleModel> newSchedules = new List<ScheduleModel>();
                foreach (var date in _dates)
                {
                    var schedules = _scheduleRepository.Items.ToList().FindAll(x => x.Data == date);

                    List<Schedule> temp = new List<Schedule>();
                    foreach (var schedule in schedules)
                    {
                        if (ClassroomSelected.Id == schedule.ClassroomId) temp.Add(schedule);
                    }
                    newSchedules.Add(new ScheduleModel(date, temp));

                }
                Data = newSchedules;
            }
        }
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}
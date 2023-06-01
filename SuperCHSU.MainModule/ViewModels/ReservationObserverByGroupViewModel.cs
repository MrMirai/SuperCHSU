using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using SuperCHSU.MainModule.Models;
using SuperCHSU.MainModule.ViewModels.Base;
using Prism.Mvvm;
using Prism.Commands;

namespace SuperCHSU.MainModule.ViewModels;

public class ReservationObserverByGroupViewModel : BindableBase, IModel
{ 
    public string Name => "Группа";
    private readonly IRepository<Schedule>? _scheduleRepository;
    public IRepository<Group> _groupRepository { get; }
    private List<ScheduleModel> _data = new List<ScheduleModel>();
    private DateTime? _date;
    private ICollection<Group> _groupCollection = new List<Group>();
    private Group _groupSelected;
    private ICollection<ScheduleModel> _schedules = new List<ScheduleModel>();
    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    private CalendarSelectionMode _selectionMode = CalendarSelectionMode.SingleDate;
    public SelectedDatesCollection _dates;


    public ReservationObserverByGroupViewModel(IRepository<Schedule> scheduleRepository, IRepository<Group> grouRepository)
    {
        _scheduleRepository = scheduleRepository;
        _groupRepository = grouRepository;

        foreach (var item in _groupRepository.Items)
        {
            GroupCollection.Add(item);
        }
        var groupedSchedules = scheduleRepository.Items.ToList().GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            _data.Add(new ScheduleModel(group.Key, group.ToList()));
        }

        SetSelectModeToSingle = new DelegateCommand(OnSetSelectModeToSingle);
        SetSelectModeToRange = new DelegateCommand(OnSetSelectModeToRange);
        GetSheduleGroupCommand = new DelegateCommand(GetSheduleGroup);

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
    public ICollection<Group> GroupCollection
    {
        get => _groupCollection;
        set => SetProperty(ref _groupCollection, value);
    }
    public Group GroupSelected
    {
        get => _groupSelected;
        set => SetProperty(ref _groupSelected, value);
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
    public ICommand GetSheduleGroupCommand { get; set; }

    private void GetSheduleGroup()
    {
        if (GroupSelected != null)
        {
            if (SelectionMode == CalendarSelectionMode.SingleDate && _date != null)
            {
                List<ScheduleModel> newSchedules = new List<ScheduleModel>();
                var schedules = _scheduleRepository.Items.ToList().FindAll(x => x.Data == (DateTime)_date);

                List<Schedule> temp = new List<Schedule>();
                foreach (var schedule in schedules)
                {
                    if (GroupSelected.Id == schedule.GroupId) temp.Add(schedule);
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
                        if (GroupSelected.Id == schedule.GroupId) temp.Add(schedule);
                    }
                    newSchedules.Add(new ScheduleModel(date, temp));

                }
                Data = newSchedules;
            }
        }
    }
}
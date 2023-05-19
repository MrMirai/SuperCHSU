using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.ViewModels.Base;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using CSLB5.Models;
using MVVM.Commands;
using MVVM.Extensions;

namespace CSLB5.ViewModels;

public class ReservationObserverByTutorViewModel : BindableBase, IModel
{
    private IRepository<Schedule> _scheduleRepository { get; }
    public IRepository<Tutor> TutorRepository { get; }

    public ReservationObserverByTutorViewModel(IRepository<Schedule> scheduleRepository, IRepository<Tutor> tutorRepository)
    {
        _scheduleRepository = scheduleRepository;
        var groupedSchedules = scheduleRepository.Items.ToList().GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            _data.Add(new ScheduleModel(group.Key, group.ToList()));
        }
       // this.WhenPropertyChanged(x => x.Lecturer, UpdateReservationsByQuery);
    }
    private List<ScheduleModel> _data = new List<ScheduleModel>();
    public List<ScheduleModel> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }

    private ICollection<Tutor> _tutorCollection = new List<Tutor>();

    public ICollection<Tutor> TutorCollection
    {
        get => _tutorCollection;
        set => SetProperty(ref _tutorCollection, value);
    }
    
    private ICollection<ScheduleModel> _schedules = new List<ScheduleModel>();

    public ICollection<ScheduleModel> Schedules
    {
        get => _schedules;
        set => SetProperty(ref _schedules, value);
    }
    
    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    
    private CalendarSelectionMode _selectionMode = CalendarSelectionMode.None;

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
    
    public string Name => "Преподаватель";

}
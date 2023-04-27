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

namespace CSLB5.ViewModels;

public class ReservationObserverByTutorViewModel : BindableBase, IModel
{
    private IRepository<Schedule> _scheduleRepository { get; }
    public IRepository<Tutor> TutorRepository { get; }

    public ReservationObserverByTutorViewModel(IRepository<Schedule> scheduleRepository, IRepository<Tutor> tutorRepository)
    {
        SetSelectModeToSingle = new RelayCommand(OnSetSelectModeToSingle);
        SetSelectModeToRange = new RelayCommand(OnSetSelectModeToRange);
        _scheduleRepository = scheduleRepository;
        TutorRepository = tutorRepository;
        foreach (var item in TutorRepository.Items)
        {
            TutorCollection.Add(item);
        }


        var groupedSchedules = _scheduleRepository.Items.GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            var model = new ScheduleModel(group.Key);
            foreach (var schedule in group)
            {
                model.Schedules.Add(schedule);
            }
            Schedules.Add(model);
        }
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
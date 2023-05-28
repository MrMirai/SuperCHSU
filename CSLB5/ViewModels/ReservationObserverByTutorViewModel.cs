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
using CSLB5.DataBase.Repositories;

namespace CSLB5.ViewModels;

public class ReservationObserverByTutorViewModel : BindableBase, IModel
{
    private IRepository<Schedule> _scheduleRepository { get; }
    public IRepository<Tutor> TutorRepository { get; }

    public ReservationObserverByTutorViewModel(IRepository<Schedule> scheduleRepository, IRepository<Tutor> tutorRepository)
    {
        _scheduleRepository = scheduleRepository;
        TutorRepository = tutorRepository;
        foreach (var item in TutorRepository.Items)
        {
            TutorCollection.Add(item);
        }
        var groupedSchedules = scheduleRepository.Items.ToList().GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            _data.Add(new ScheduleModel(group.Key, group.ToList()));
        }
        SetSelectModeToSingle = new RelayCommand(OnSetSelectModeToSingle);
        SetSelectModeToRange = new RelayCommand(OnSetSelectModeToRange);
        GetSheduleTutorCommand = new RelayCommand(GetSheduleTutor);
        // this.WhenPropertyChanged(x => x.Lecturer, UpdateReservationsByQuery);
    }
    private List<ScheduleModel> _data = new List<ScheduleModel>();
    public List<ScheduleModel> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }

    private DateTime? _date;
    public DateTime? Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }

    private ICollection<Tutor> _tutorCollection = new List<Tutor>();

    public ICollection<Tutor> TutorCollection
    {
        get => _tutorCollection;
        set => SetProperty(ref _tutorCollection, value);
    }

    private Tutor _tutorSelected;

    public Tutor TutorSelected
    {
        get => _tutorSelected;
        set => SetProperty(ref _tutorSelected, value);
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
    
    private CalendarSelectionMode _selectionMode = CalendarSelectionMode.SingleDate;

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

    public SelectedDatesCollection _dates;

    public SelectedDatesCollection Dates
    {
       get => _dates;
       set => SetProperty(ref _dates, value);
    }

    public ICommand GetSheduleTutorCommand { get; set; }

    private void GetSheduleTutor()
    {
        if (TutorSelected != null)
        {
            if (SelectionMode == CalendarSelectionMode.SingleDate && _date != null)
            {
                List<ScheduleModel> newSchedules = new List<ScheduleModel>();
                var schedules = _scheduleRepository.Items.ToList().FindAll(x => x.Data == (DateTime)_date);

                List<Schedule> temp = new List<Schedule>();
                foreach (var schedule in schedules)
                {
                    if (TutorSelected.Id == schedule.TutorId) temp.Add(schedule);
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
                        if (TutorSelected.Id == schedule.TutorId) temp.Add(schedule);
                    }
                    newSchedules.Add(new ScheduleModel(date, temp));

                }
                Data = newSchedules;
            }
        }
    }
    public string Name => "Преподаватель";

}
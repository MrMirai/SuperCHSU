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
    public string Name => "Преподаватель";
    private IRepository<Schedule> _scheduleRepository { get; }
    public IRepository<Tutor> TutorRepository { get; }
    private List<ScheduleModel> _data = new List<ScheduleModel>();
    private DateTime? _date;
    private ICollection<Tutor> _tutorCollection = new List<Tutor>();
    private Tutor _tutorSelected;
    private ICollection<ScheduleModel> _schedules = new List<ScheduleModel>();
    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    private CalendarSelectionMode _selectionMode = CalendarSelectionMode.SingleDate;
    public SelectedDatesCollection _dates;


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
    public ICollection<Tutor> TutorCollection
    {
        get => _tutorCollection;
        set => SetProperty(ref _tutorCollection, value);
    }
    public Tutor TutorSelected
    {
        get => _tutorSelected;
        set => SetProperty(ref _tutorSelected, value);
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

}
using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.ViewModels.Base;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM.Commands;

namespace CSLB5.ViewModels;

public class ReservationObserverByTutorViewModel : BindableBase, IModel
{
    public IRepository<Schedule>? ScheduleRepository { get; }
    public IRepository<Tutor> TutorRepository { get; }

    public ReservationObserverByTutorViewModel(IRepository<Schedule>? scheduleRepository, IRepository<Tutor> tutorRepository)
    {
        SetSelectModeToSingle = new RelayCommand(OnSetSelectModeToSingle);
        SetSelectModeToRange = new RelayCommand(OnSetSelectModeToRange);
        ScheduleRepository = scheduleRepository;
        TutorRepository = tutorRepository;
        foreach (var item in TutorRepository.Items)
        {
            TutorCollection.Add(item);
        }
    }

    private ObservableCollection<Tutor> _tutorCollection = new ObservableCollection<Tutor>();

    public ObservableCollection<Tutor> TutorCollection
    {
        get { return _tutorCollection; }
        set { SetProperty(ref _tutorCollection, value); }
    }
    
    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    
    private CalendarSelectionMode _selectionMode;

    public CalendarSelectionMode SelectionMode
    {
        get => _selectionMode;
        set => SetProperty(ref _selectionMode, value);
    }
    
    public ICommand SetSelectModeToSingle { get; set; }

    private void OnSetSelectModeToSingle()
    {
        _selectionMode = CalendarSelectionMode.SingleDate;
    }
    
    public ICommand SetSelectModeToRange { get; set; }

    private void OnSetSelectModeToRange()
    {
        _selectionMode = CalendarSelectionMode.SingleRange;
    }
    
    public string Name => "Преподаватель";

}
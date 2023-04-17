using System.Collections.Generic;
using System.Windows.Input;
using MVVM;
using MVVM.Commands;
using System;
using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using System.Linq;

namespace CSLB5.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel(IRepository<Schedule> scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        Models = new();
        Models.Add(new ReservationObserverByGroupViewModel(_scheduleRepository));
        Models.Add(new ReservationObserverByTutorViewModel(_scheduleRepository));
        Models.Add(new ReservationObserverByClassroomViewModel(_scheduleRepository));
        Models.Add(new ReservationObserverSettingsViewModel(_scheduleRepository));
        Models.Add(new ReservationObserverGanttChartViewModel(_scheduleRepository));
        
        //SelectModel = Models[0];
        OpenObserverByLecture = new RelayCommand(OnOpenObserverByLecture);
        OpenObserverByTutor = new RelayCommand(OnOpenObserverByTutor);
        OpenObserverByClassroom = new RelayCommand(OnOpenObserverByClassroom);
        OpenObserverSettings = new RelayCommand(OnOpenObserverSettings);
        OpenObserverGanttChart = new RelayCommand(OnOpenObserverGanttChart);
        
        
        var lectures = scheduleRepository.Items.Take(9).ToArray();
    }
    
    private readonly IRepository<Schedule> _scheduleRepository;
    public List<BindableBase> Models { get; private set; }

    private BindableBase _selectModel;
    public BindableBase SelectModel
    {
        get => _selectModel;
        set => SetProperty(ref _selectModel, value);
    }

    private string _title = "SuperCHSU";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private DateOnly _value = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }

    public ICommand OpenObserverByLecture { get;  }
    
    private void OnOpenObserverByLecture()
    {
        SelectModel = Models[0];
    }
    
    public ICommand OpenObserverByTutor { get;  }
    
    private void OnOpenObserverByTutor()
    {
        SelectModel = Models[1];
    }
    
    public ICommand OpenObserverByClassroom { get; }
    
    private void OnOpenObserverByClassroom()
    {
        SelectModel = Models[2];
    }

    public ICommand OpenObserverSettings { get; }

    private void OnOpenObserverSettings()
    {
        SelectModel = Models[3];
    }
    
    public ICommand OpenObserverGanttChart { get; }

    private void OnOpenObserverGanttChart()
    {
        SelectModel = Models[4];
    }
}
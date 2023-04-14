using System.Collections.Generic;
using System.Windows.Input;
using MVVM;
using MVVM.Commands;

namespace CSLB5.ViewModels;

public class MainWindowViewModel : BindableBase
{
    public MainWindowViewModel()
    {
        Models = new();
        Models.Add(new ReservationObserverByLectureViewModel());
        Models.Add(new ReservationObserverByTutorViewModel());
        Models.Add(new ReservationObserverByClassroomViewModel());
        Models.Add(new ReservationObserverSettingsViewModel());
        Models.Add(new ReservationObserverGanttChartViewModel());
        
        //SelectModel = Models[0];
        OpenObserverByLecture = new RelayCommand(OnOpenObserverByLecture);
        OpenObserverByTutor = new RelayCommand(OnOpenObserverByTutor);
        OpenObserverByClassroom = new RelayCommand(OnOpenObserverByClassroom);
        OpenObserverSettings = new RelayCommand(OnOpenObserverSettings);
        OpenObserverGanttChart = new RelayCommand(OnOpenObserverGanttChart);
    }
    
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
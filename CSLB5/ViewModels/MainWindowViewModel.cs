using System.Collections.Generic;
using System.Windows.Input;
using MVVM;
using MVVM.Commands;
using System;
using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace CSLB5.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private readonly IRepository<Schedule> _scheduleRepository;
    private readonly IRepository<Tutor> _tutorRepository;
    private readonly IRepository<Classroom> _classroomRepository;
    private readonly IRepository<Group> _groupRepository;
    private BindableBase _selectModel;
    private string _title = "SuperCHSU";
    private ObservableCollection<SolidColorBrush> _backgrounds = new ObservableCollection<SolidColorBrush>();
    private ObservableCollection<SolidColorBrush> _foregrounds = new ObservableCollection<SolidColorBrush>();


    public MainWindowViewModel(IRepository<Schedule> scheduleRepository, IRepository<Tutor> tutorRepository, IRepository<Classroom> classroomRepository, IRepository<Group> groupRepository)
    {
        _scheduleRepository = scheduleRepository;
        _tutorRepository = tutorRepository;
        _classroomRepository = classroomRepository;
        _groupRepository = groupRepository;

        Models = new();
        Models.Add(new ReservationObserverByGroupViewModel(_scheduleRepository, _groupRepository));
        Models.Add(new ReservationObserverByTutorViewModel(_scheduleRepository, _tutorRepository));
        Models.Add(new ReservationObserverByClassroomViewModel(_scheduleRepository,_classroomRepository));
        Models.Add(new ReservationObserverGanttChartViewModel(_scheduleRepository));

        OpenObserverByGroup = new RelayCommand(OnOpenObserverByGroup);
        OpenObserverByTutor = new RelayCommand(OnOpenObserverByTutor);
        OpenObserverByClassroom = new RelayCommand(OnOpenObserverByClassroom);
        OpenObserverGanttChart = new RelayCommand(OnOpenObserverGanttChart);


        var lectures = scheduleRepository.Items.Take(9).ToArray();

        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));

        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));

    }


    public List<BindableBase> Models { get; private set; }
    public BindableBase SelectModel
    {
        get => _selectModel;
        set => SetProperty(ref _selectModel, value);
    }
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    public ObservableCollection<SolidColorBrush> Backgrounds
    {
        get => _backgrounds;
        set => SetProperty(ref _backgrounds, value);
    }
    public ObservableCollection<SolidColorBrush> Foregrounds
    {
        get => _foregrounds;
        set => SetProperty(ref _foregrounds, value);
    }

    public ICommand OpenObserverByGroup { get;  }
    
    private void OnOpenObserverByGroup()
    {
        SelectModel = Models[0];
        for (int i = 0; i < 4; i++)
        {            
                Backgrounds[i] = new SolidColorBrush(Colors.White);
                Foregrounds[i] = new SolidColorBrush(Colors.Black);         
        }

        Backgrounds[0] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        Foregrounds[0] = new SolidColorBrush(Colors.White);
    }
    
    public ICommand OpenObserverByTutor { get;  }
    
    private void OnOpenObserverByTutor()
    {
        SelectModel = Models[1];
        for (int i = 0; i < 4; i++)
        {
            Backgrounds[i] = new SolidColorBrush(Colors.White);
            Foregrounds[i] = new SolidColorBrush(Colors.Black);
        }

        Backgrounds[1] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        Foregrounds[1] = new SolidColorBrush(Colors.White);
    }
    
    public ICommand OpenObserverByClassroom { get; }
    
    private void OnOpenObserverByClassroom()
    {
        SelectModel = Models[2];
        for (int i = 0; i < 4; i++)
        {
            Backgrounds[i] = new SolidColorBrush(Colors.White);
            Foregrounds[i] = new SolidColorBrush(Colors.Black);
        }
        Backgrounds[2] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        Foregrounds[2] = new SolidColorBrush(Colors.White);
    }

    
    public ICommand OpenObserverGanttChart { get; }

    private void OnOpenObserverGanttChart()
    {
        SelectModel = Models[3];
        for (int i = 0; i < 4; i++)
        {
            Backgrounds[i] = new SolidColorBrush(Colors.White);
            Foregrounds[i] = new SolidColorBrush(Colors.Black);
        }

        Backgrounds[3] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        Foregrounds[3] = new SolidColorBrush(Colors.White);
    }
}
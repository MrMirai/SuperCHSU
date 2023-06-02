using System.Collections.Generic;
using System.Windows.Input;
using Prism.Mvvm;
using System;
using SuperCHSU.MainModule.DataBase.Entities;
using SuperCHSU.MainModule.DataBase.Interfaces;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Regions;
using SuperCHSU.MainModule.DataBase.Context;
using SuperCHSU.MainModule.DataBase.Repositories;
using SuperCHSU.MainModule.Views;
using SuperCHSU.Shared;

namespace SuperCHSU.MainModule.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private readonly IRepository<Schedule> _scheduleRepository;
    private readonly IRepository<Tutor> _tutorRepository;
    private readonly IRepository<Classroom> _classroomRepository;
    private readonly IRepository<Group> _groupRepository;
    private string _title = "SuperCHSU";
    private ObservableCollection<SolidColorBrush> _backgrounds = new ObservableCollection<SolidColorBrush>();
    private ObservableCollection<SolidColorBrush> _foregrounds = new ObservableCollection<SolidColorBrush>();


    public MainWindowViewModel(IRepository<Schedule> scheduleRepository, IRepository<Tutor> tutorRepository, IRepository<Classroom> classroomRepository, IRepository<Group> groupRepository, IRegionManager regionManager)
    {
        _scheduleRepository = scheduleRepository;
        _tutorRepository = tutorRepository;
        _classroomRepository = classroomRepository;
        _groupRepository = groupRepository;
        _regionManager = regionManager;

        OpenObserverByGroup = new DelegateCommand(OnOpenObserverByGroup);
        OpenObserverByTutor = new DelegateCommand(OnOpenObserverByTutor);
        OpenObserverByClassroom = new DelegateCommand(OnOpenObserverByClassroom);
        OpenObserverGanttChart = new DelegateCommand(OnOpenObserverGanttChart);


        //var lectures = scheduleRepository.Items.Take(9).ToArray();

        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));
        _backgrounds.Add(new SolidColorBrush(Colors.White));

        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));
        _foregrounds.Add(new SolidColorBrush(Colors.Black));

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
        //var view = new ReservationObserverByGroupView();
        //_regionManager.Regions["AddingView"].Add(view);
        //_regionManager.Regions["AddingView"].Activate(view);
        _regionManager.RequestNavigate(RegionNames.ContentRegion, "ReservationObserverByGroupView");
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
        _regionManager.RequestNavigate(RegionNames.ContentRegion, "ReservationObserverByTutorView");
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
        _regionManager.RequestNavigate(RegionNames.ContentRegion, "ReservationObserverByClassroomView");
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
        _regionManager.RequestNavigate(RegionNames.ContentRegion, "ReservationObserverGanttChartView");
        for (int i = 0; i < 4; i++)
        {
            Backgrounds[i] = new SolidColorBrush(Colors.White);
            Foregrounds[i] = new SolidColorBrush(Colors.Black);
        }

        Backgrounds[3] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E31E24"));
        Foregrounds[3] = new SolidColorBrush(Colors.White);
    }
}
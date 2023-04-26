using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.Models;
using CSLB5.ViewModels.Base;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Windows.Markup;

namespace CSLB5.ViewModels;

public class ReservationObserverByClassroomViewModel : BindableBase, IModel
{
    public string Name => "Аудитории";
    private readonly IRepository<Schedule>? _scheduleRepository;


    public ReservationObserverByClassroomViewModel(IRepository<Schedule>? scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        foreach (var item in _scheduleRepository.Items)
        {
            Data.Add(item);
        }

    }
    
    private ObservableCollection<Schedule> _data = new ObservableCollection<Schedule>();
    public ObservableCollection<Schedule> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }
}
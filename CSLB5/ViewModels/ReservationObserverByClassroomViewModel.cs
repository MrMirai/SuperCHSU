using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.Models;
using CSLB5.ViewModels.Base;
using MVVM;
using System;
using System.Collections.Generic;
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
        //ObservableCollection<Schedule> _temp = new ObservableCollection<Schedule>();
        //foreach (var item in _scheduleRepository.Items)
        //{
        //    _temp.Add(item);
        //}
        var groupedSchedules = scheduleRepository.Items.ToList().GroupBy(x => x.Data);

        foreach (var group in groupedSchedules)
        {
            _data.Add(new ScheduleModel(group.Key, group.ToList()));
        }
    }

    private List<ScheduleModel> _data = new List<ScheduleModel>();
    public List<ScheduleModel> Data
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }
}
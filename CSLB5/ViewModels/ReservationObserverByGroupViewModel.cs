using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverByGroupViewModel : BindableBase, IModel
{
    private readonly IRepository<Schedule> _scheduleRepository;

    public ReservationObserverByGroupViewModel(IRepository<Schedule> scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
        foreach (var item in _scheduleRepository.Items.ToArray())
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
    
    public string Name => "Группа";
}
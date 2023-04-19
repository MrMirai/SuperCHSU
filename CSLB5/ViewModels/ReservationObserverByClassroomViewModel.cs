using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverByClassroomViewModel : BindableBase, IModel
{
    private readonly IRepository<Schedule>? _scheduleRepository;


    public ReservationObserverByClassroomViewModel(IRepository<Schedule>? scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public string Name => "Аудитории";
}
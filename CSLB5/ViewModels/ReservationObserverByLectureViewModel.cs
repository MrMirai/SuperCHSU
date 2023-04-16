using System.Linq;
using CSLB5.DataBase.Entities;
using CSLB5.DataBase.Interfaces;
using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverByLectureViewModel : BindableBase, IModel
{
    public ReservationObserverByLectureViewModel()
    {

    }

    public string Name => "Предмет";
}
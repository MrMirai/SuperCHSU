using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverByClassroomViewModel : BindableBase, IModel
{
    public ReservationObserverByClassroomViewModel()
    {
        
    }

    public string Name => "Аудитории";
}
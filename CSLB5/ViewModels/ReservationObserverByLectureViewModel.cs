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
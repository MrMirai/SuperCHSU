using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverByTutorViewModel : BindableBase, IModel
{
    public ReservationObserverByTutorViewModel()
    {
        
    }
    
    public string Name => "Преподаватель";
}
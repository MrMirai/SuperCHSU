using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverGanttChartViewModel : BindableBase, IModel
{
    public ReservationObserverGanttChartViewModel()
    {
    }


    public string Name => "Диаграмма Ганта";
}
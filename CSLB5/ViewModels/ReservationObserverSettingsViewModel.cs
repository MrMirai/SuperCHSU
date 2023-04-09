using CSLB5.ViewModels.Base;
using MVVM;

namespace CSLB5.ViewModels;

public class ReservationObserverSettingsViewModel : BindableBase, IModel
{
    public ReservationObserverSettingsViewModel()
    {
    }

    public string Name => "Настройки";
}
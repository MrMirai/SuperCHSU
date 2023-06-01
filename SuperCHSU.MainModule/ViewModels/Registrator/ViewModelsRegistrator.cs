using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;

namespace SuperCHSU.MainModule.ViewModels.Registrator;

public static class ViewModelsRegistrator
{
    public static IContainerRegistry AddViewModels(this IContainerRegistry services) => services
        .RegisterSingleton<MainWindowViewModel>()
        .RegisterSingleton<ReservationObserverByClassroomViewModel>()
        .RegisterSingleton<ReservationObserverByGroupViewModel>()
        .RegisterSingleton<ReservationObserverByTutorViewModel>()
        .RegisterSingleton<ReservationObserverGanttChartViewModel>();
}
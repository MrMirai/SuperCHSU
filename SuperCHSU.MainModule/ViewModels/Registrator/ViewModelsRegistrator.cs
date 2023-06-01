using Microsoft.Extensions.DependencyInjection;

namespace SuperCHSU.MainModule.ViewModels.Registrator;

public static class ViewModelsRegistrator
{
    public static IServiceCollection AddViewModels(this IServiceCollection services) => services
        .AddSingleton<MainWindowViewModel>()
        .AddSingleton<ReservationObserverByClassroomViewModel>()
        .AddSingleton<ReservationObserverByGroupViewModel>()
        .AddSingleton<ReservationObserverByTutorViewModel>()
        .AddSingleton<ReservationObserverGanttChartViewModel>();
}
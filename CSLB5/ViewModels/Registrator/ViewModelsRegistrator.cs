using Microsoft.Extensions.DependencyInjection;

namespace CSLB5.ViewModels.Registrator;

public static class ViewModelsRegistrator
{
    public static IServiceCollection AddViewModels(this IServiceCollection services) => services
        .AddSingleton<MainWindowViewModel>()
        .AddSingleton<ReservationObserverByClassroomViewModel>()
        .AddSingleton<ReservationObserverByLectureViewModel>()
        .AddSingleton<ReservationObserverByTutorViewModel>()
        .AddSingleton<ReservationObserverSettingsViewModel>()
        .AddSingleton<ReservationObserverGanttChartViewModel>();
}
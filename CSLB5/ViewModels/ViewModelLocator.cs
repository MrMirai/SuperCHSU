using Microsoft.Extensions.DependencyInjection;

namespace CSLB5.ViewModels;

public class ViewModelLocator
{
    public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
}
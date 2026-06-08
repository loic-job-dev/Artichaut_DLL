using ArtichautDesktopApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.Views;

public partial class Landing : UserControl
{
    public Landing()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<LandingViewModel>();
    }
}
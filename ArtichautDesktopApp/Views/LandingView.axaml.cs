using ArtichautDesktopApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.Views;

public partial class LandingView : UserControl
{
    public LandingView()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<LandingViewModel>();
    }
}
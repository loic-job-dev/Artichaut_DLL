using ArtichautDesktopApp.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp.Views.Components;

public partial class SideMenu : UserControl
{
    public SideMenu()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<SideMenuViewModel>();
    }
}
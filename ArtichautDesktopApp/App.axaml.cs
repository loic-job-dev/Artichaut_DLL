using System;
using ArtichautDesktopApp.Services;
using ArtichautLibrary;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace ArtichautDesktopApp;

public partial class App : Avalonia.Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        Services = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Views.MainWindow
            {
                DataContext = Services.GetRequiredService<ViewModels.MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // API Client
        services.AddArtichautClient("http://localhost:8080");

        // Navigation
        services.AddSingleton<INavigationService, NavigationService>();
        
        // ViewModels
        services.AddSingleton<ViewModels.MainWindowViewModel>();
        services.AddTransient<ViewModels.LoginViewModel>();
        services.AddTransient<ViewModels.LandingViewModel>();
        services.AddSingleton<ViewModels.SideMenuViewModel>();
        services.AddTransient<ViewModels.CheckinViewModel>();
        services.AddTransient<ViewModels.BookingSearchViewModel>();

    }
}
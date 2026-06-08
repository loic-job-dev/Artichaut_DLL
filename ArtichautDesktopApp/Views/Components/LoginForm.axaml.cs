using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ArtichautDesktopApp.Views.Components;

public partial class LoginForm : UserControl
{
    public LoginForm()
    {
        InitializeComponent();
    }
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine($"Login : {Email.Text}");
    }
}
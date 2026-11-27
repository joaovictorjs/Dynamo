using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Dynamo.Presentation.ViewModels;
using Dynamo.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dynamo.Presentation;

public partial class App : Application
{
    private IHost? _host;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _host = CreateHostBuilder().Build();
            _host.Start();

            desktop.MainWindow = _host.Services.GetRequiredService<MainWindow>();
            desktop.Exit += OnDesktopExit;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static HostApplicationBuilder CreateHostBuilder()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainWindow>();

        return builder;
    }

    private void OnDesktopExit(object? sender, ControlledApplicationLifetimeExitEventArgs e)
    {
        if (_host is null)
        {
            return;
        }

        _host.StopAsync().GetAwaiter().GetResult();
        _host.Dispose();
        _host = null;
    }
}

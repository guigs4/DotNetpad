using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Engine.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNetpadUI
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<IDataSession, DataSession>();
            })
            .Build();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            //var services = new ServiceCollection().AddSingleton<IServiceCollection>().BuildServiceProvider();
            //var viewModel = ActivatorUtilities.CreateInstance<DataSession>(services);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            //{
            //    desktop.MainWindow = new MainWindow();
            //}

            base.OnFrameworkInitializationCompleted();
        }
    }
}

using Avalonia;
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
                services.AddSingleton<MainWindow>(); //TRANSIENT
                services.AddSingleton<IDataSessionVM, DataSessionVM>(); //TRANSIENT
                services.AddSingleton<IUserPreferencesVM, UserPreferencesVM>();
            })
            .Build();
        }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();
            base.OnFrameworkInitializationCompleted();
        }
    }
}

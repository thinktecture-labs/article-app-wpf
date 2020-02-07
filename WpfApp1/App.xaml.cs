using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Windows;
using WpfApp1.DataAccessLayer;
using WpfApp1.ViewModels;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       ConfigureServices(services);
                   })
                   .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<ArticleService>();
            services.AddSingleton<CategoryService>();
            services.AddSingleton<DemoSelectorWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var demoSelectorWindow = host.Services.GetRequiredService<DemoSelectorWindow>();
            demoSelectorWindow.DataContext = new DemoSelectorWindowViewModel(host.Services.GetRequiredService<ArticleService>(),
                host.Services.GetRequiredService<CategoryService>());
            demoSelectorWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}

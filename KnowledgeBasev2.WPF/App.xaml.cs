using KnowledgeBasev2.WPF.HostBuilder;
using KnowledgeBasev2.WPF.Manager;
using KnowledgeBasev2.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Windows;



namespace KnowledgeBasev2.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddScoped<HttpClient>();
                //----------------------------------------------------------
                //--------- View Registration
                //----------------------------------------------------------


                //----------------------------------------------------------
                //--------- Manager Registration
                //----------------------------------------------------------
                

                //----------------------------------------------------------
                //--------- Service Registration
                //----------------------------------------------------------
                

                //----------------------------------------------------------
                //--------- Factory Registration
                //----------------------------------------------------------
                //services.AddSingleton<Func<DashboardViewModel>>(s => () => s.GetRequiredService<DashboardViewModel>());
                //services.AddSingleton<Func<CommandPageViewModel>>(s => () => s.GetRequiredService<CommandPageViewModel>());
                //services.AddSingleton<Func<CodePageViewModel>>(s => () => s.GetRequiredService<CodePageViewModel>());
                //services.AddSingleton<Func<DocumentationPageViewModel>>(s => () => s.GetRequiredService<DocumentationPageViewModel>());



            })
            .RegisterViewModels()    
            .RegisterManagers()
            .RegisterServices()
            .RegisterFactoryFunctions()
            .Build();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();

            DataManager dataManager = host.Services.GetService<DataManager>();
            dataManager.PreLoadData();

            MainWindow = new MainWindow()
            {
                DataContext = host.Services.GetRequiredService<MainWindowViewModel>()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();

            base.OnExit(e);
        }
    }

}

using KnowledgeBasev2.Application.Services;
using KnowledgeBasev2.WPF.Manager;
using KnowledgeBasev2.WPF.Services;
using KnowledgeBasev2.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.WPF.HostBuilder
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder RegisterViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<CommandPageViewModel>();
                services.AddSingleton<CodePageViewModel>();
                services.AddSingleton<DocumentationPageViewModel>();
            });
            return hostBuilder;
        }
        public static IHostBuilder RegisterViews(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {

            });
            return hostBuilder;
        }
        public static IHostBuilder RegisterManagers(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<NavigationManager>();
                services.AddSingleton<DataManager>();
            });
            return hostBuilder;
        }
        public static IHostBuilder RegisterServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<NavigationService<DashboardViewModel>>();
                services.AddSingleton<NavigationService<CommandPageViewModel>>();
                services.AddSingleton<NavigationService<CodePageViewModel>>();
                services.AddSingleton<NavigationService<DocumentationPageViewModel>>();
                //  -----
                services.AddSingleton<CommandService>();
                services.AddSingleton<CodeService>();
                services.AddSingleton<DocumentationService>();
            });
            return hostBuilder;
        }
        public static IHostBuilder RegisterFactoryFunctions(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<Func<DashboardViewModel>>(
                    s => () => s.GetRequiredService<DashboardViewModel>());
                services.AddSingleton<Func<CommandPageViewModel>>(
                    s => () => s.GetRequiredService<CommandPageViewModel>());
                services.AddSingleton<Func<CodePageViewModel>>(
                    s => () => s.GetRequiredService<CodePageViewModel>());
                services.AddSingleton<Func<DocumentationPageViewModel>>(
                    s => () => s.GetRequiredService<DocumentationPageViewModel>());

            });
            return hostBuilder;
        }
    }
}

using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WPF.MainApp.ViewModels;
using Presentation.WPF.MainApp.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Presentation.WPF.MainApp;

public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IFileService>(new FileService(AppDomain.CurrentDomain.BaseDirectory, "users.json"));
                services.AddTransient<IContactService, ContactService>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<ContactsViewModel>();
                services.AddTransient<ContactsView>();

                services.AddTransient<AddContactViewModel>();
                services.AddTransient<AddContactView>();

                services.AddTransient<ContactDetailViewModel>();
                services.AddTransient<ContactDetailView>();

                services.AddTransient<EditContactViewModel>();
                services.AddTransient<EditContactView>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<ContactsViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }

}

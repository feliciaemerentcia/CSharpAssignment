﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WPF.MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{

    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        //CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
    }
}



﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KnowledgeBasev2.WPF.Manager;
using KnowledgeBasev2.WPF.Messages;
using KnowledgeBasev2.WPF.Services;
using System.Windows;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataManager _dataManager;

        private readonly NavigationService<DashboardViewModel> _dashboardNavigator;
        private readonly NavigationService<CommandPageViewModel> _commandNavigator;
        private readonly NavigationService<CodePageViewModel> _codeNavigator;
        private readonly NavigationService<DocumentationPageViewModel> _documentationNavigator;

        public ObservableRecipient? CurrentViewModel => _navigationManager.CurrentViewModel;

        [ObservableProperty]
        private int activeView = 0;

        

        public double ScreenWidth => System.Windows.SystemParameters.PrimaryScreenWidth;
        public double ScreenHeight => System.Windows.SystemParameters.PrimaryScreenHeight;
        [ObservableProperty]
        private double appWidth;
        [ObservableProperty]
        private double appHeight;

        public MainWindowViewModel(NavigationService<DashboardViewModel> dashboardNavigator, 
            NavigationService<CommandPageViewModel> commandNavigator, 
            NavigationService<CodePageViewModel> codeNavigator, 
            NavigationService<DocumentationPageViewModel> documentationNavigator,
            NavigationManager navigationManager,
            DataManager dataManager)
        {
            _dashboardNavigator = dashboardNavigator;
            _commandNavigator = commandNavigator;
            _codeNavigator = codeNavigator;
            _documentationNavigator = documentationNavigator;
            _navigationManager = navigationManager;
            _dataManager = dataManager;

            _navigationManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _dataManager.FinishedLoadingData += OnFinishedLoadingData;

            WeakReferenceMessenger.Default.Register<ApplicationSizeMessage>(this, (r, m) =>
            {
                AppWidth = m.Value.Width;
                AppHeight = m.Value.Height;
            });
        }


        private void OnFinishedLoadingData()
        {
            NavigateToDashboard();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        [RelayCommand]
        public void NavigateToDashboard()
        {
            _dashboardNavigator.Navigate();
            ActiveView = 0;
        }
        [RelayCommand]
        public void NavigateToCommandView()
        {
            _commandNavigator.Navigate();
            ActiveView = 50;
        }
        [RelayCommand]
        public void NavigateToCodeView()
        {
            _codeNavigator.Navigate();
            ActiveView = 100;
        }
        [RelayCommand]
        public void NavigateToDocumentationView()
        {
            _documentationNavigator.Navigate();
            ActiveView = 150;
        }
    }
}
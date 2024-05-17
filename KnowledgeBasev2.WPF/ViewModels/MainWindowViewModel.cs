using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnowledgeBasev2.WPF.Manager;
using KnowledgeBasev2.WPF.Services;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private readonly NavigationManager _navigationManager;

        private readonly NavigationService<DashboardViewModel> _dashboardNavigator;
        private readonly NavigationService<CommandPageViewModel> _commandNavigator;
        private readonly NavigationService<CodePageViewModel> _codeNavigator;
        private readonly NavigationService<DocumentationPageViewModel> _documentationNavigator;

        public ObservableRecipient? CurrentViewModel => _navigationManager.CurrentViewModel;

        [ObservableProperty]
        private int activeView = 0;

        public MainWindowViewModel(NavigationService<DashboardViewModel> dashboardNavigator, 
            NavigationService<CommandPageViewModel> commandNavigator, 
            NavigationService<CodePageViewModel> codeNavigator, 
            NavigationService<DocumentationPageViewModel> documentationNavigator,
            NavigationManager navigationManager)
        {
            _dashboardNavigator = dashboardNavigator;
            _commandNavigator = commandNavigator;
            _codeNavigator = codeNavigator;
            _documentationNavigator = documentationNavigator;
            _navigationManager = navigationManager;

            _navigationManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
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

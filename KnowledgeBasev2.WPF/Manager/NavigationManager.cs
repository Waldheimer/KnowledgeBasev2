using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.WPF.ViewModels;

namespace KnowledgeBasev2.WPF.Manager
{
    public class NavigationManager
    {
        private ObservableRecipient? _currentViewModel;
        public ObservableRecipient? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public NavigationManager()
        {
        }

        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}

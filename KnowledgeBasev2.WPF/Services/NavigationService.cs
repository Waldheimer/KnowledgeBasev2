using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.WPF.Manager;

namespace KnowledgeBasev2.WPF.Services
{
    public class NavigationService<TViewModel> where TViewModel : ObservableRecipient
    {
        private readonly NavigationManager _navigationManager;
        private readonly Func<TViewModel> _viewModelFactory;

        public NavigationService(NavigationManager navigationManager, Func<TViewModel> viewModelFactory)
        {
            _navigationManager = navigationManager;
            _viewModelFactory = viewModelFactory;
        }

        public void Navigate()
        {
            _navigationManager.CurrentViewModel = _viewModelFactory();
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.WPF.Manager;
using System.Collections.ObjectModel;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class DashboardViewModel : ObservableRecipient
    {

        
        public int CommandCount => Commands.Count;
        public int CodeCount => Codes.Count;
        public int DocumentationCount => Documentations.Count;

        public ObservableCollection<ReadUpdateDTO> Commands => _dataManager.Commands;
        public ObservableCollection<ReadUpdateDTO> Codes => _dataManager.Codes;
        public ObservableCollection<ReadUpdateDTO> Documentations => _dataManager.Documentations;

        public ObservableCollection<string> Systems => _dataManager.Systems;
        public ObservableCollection<string> Techs => _dataManager.Techs;
        public ObservableCollection<string> Langs => _dataManager.Langs;

        private readonly DataManager _dataManager;

        public DashboardViewModel(DataManager dataManager)
        {
            _dataManager = dataManager;

        }


    }
}

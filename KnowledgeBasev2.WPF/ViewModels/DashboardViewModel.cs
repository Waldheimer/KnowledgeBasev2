using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.WPF.Manager;
using System.Collections.ObjectModel;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class DashboardViewModel : ObservableRecipient
    {

        
<<<<<<< HEAD
        public int? CommandCount => Commands?.Count();
        public int? CodeCount => Codes?.Count;
        public int? DocuCount => Documentations?.Count;

        public IEnumerable<ReadUpdateDTO>? Commands => _dataManager.Commands;
        public ObservableCollection<ReadUpdateDTO>? Codes => _dataManager.Codes;
        public ObservableCollection<ReadUpdateDTO>? Documentations => _dataManager.Documentations;

        public ObservableCollection<string>? Systems => _dataManager.Systems;
        public ObservableCollection<string>? Techs => _dataManager.Techs;
        public ObservableCollection<string>? Langs => _dataManager.Langs;

        public Dictionary<string, int>? CommandSystemCount => _dataManager.CommandSystemsCount;
        public Dictionary<string, int>? CommandTechCount => _dataManager.CommandTechsCount;
        public Dictionary<string, int>? CommandLangCount => _dataManager.CommandLangsCount;
        public Dictionary<string, int>? CodeSystemCount => _dataManager.CodeSystemsCount;
        public Dictionary<string, int>? CodeTechCount => _dataManager.CodeTechsCount;
        public Dictionary<string, int>? CodeLangCount => _dataManager.CodeLangsCount;
        public Dictionary<string, int>? DocuSystemCount => _dataManager.DocuSystemsCount;
        public Dictionary<string, int>? DocuTechCount => _dataManager.DocuTechsCount;
        public Dictionary<string, int>? DocuLangCount => _dataManager.DocuLangsCount;
=======
        public int CommandCount => Commands.Count;
        public int CodeCount => Codes.Count;
        public int DocumentationCount => Documentations.Count;

        public ObservableCollection<ReadUpdateDTO> Commands => _dataManager.Commands;
        public ObservableCollection<ReadUpdateDTO> Codes => _dataManager.Codes;
        public ObservableCollection<ReadUpdateDTO> Documentations => _dataManager.Documentations;

        public ObservableCollection<string> Systems => _dataManager.Systems;
        public ObservableCollection<string> Techs => _dataManager.Techs;
        public ObservableCollection<string> Langs => _dataManager.Langs;
>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198

        private readonly DataManager _dataManager;

        public DashboardViewModel(DataManager dataManager)
        {
            _dataManager = dataManager;

        }


    }
}

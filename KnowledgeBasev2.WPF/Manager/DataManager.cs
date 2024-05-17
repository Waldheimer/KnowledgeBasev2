using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.Application.Services;
using KnowledgeBasev2.Domain.DTOs;
using System.Collections.ObjectModel;

namespace KnowledgeBasev2.WPF.Manager
{
    public partial class DataManager : ObservableObject
    {
        private readonly CommandService _commandService;
        private readonly CodeService _codeService;
        private readonly DocumentationService _documentationService;

        [ObservableProperty]
        private ObservableCollection<ReadUpdateDTO>? commands;
        [ObservableProperty]
        private ObservableCollection<ReadUpdateDTO>? codes;
        [ObservableProperty]
        private ObservableCollection<ReadUpdateDTO>? documentations;

        [ObservableProperty]
        private ObservableCollection<string>? systems;
        [ObservableProperty]
        private ObservableCollection<string>? techs;
        [ObservableProperty]
        private ObservableCollection<string>? langs;
        public DataManager( CommandService commandService, 
                            CodeService codeService, 
                            DocumentationService documentationService)
        {
            _commandService = commandService;
            _codeService = codeService;
            _documentationService = documentationService;


        }

        public async void PreLoadData()
        {
            var cmds = await _commandService.GetAsync();
            Commands = new ObservableCollection<ReadUpdateDTO>(cmds);
            Codes = new ObservableCollection<ReadUpdateDTO>(await _codeService.GetAsync());
            Documentations = new ObservableCollection<ReadUpdateDTO>(await _documentationService.GetAsync());
            Systems = new ObservableCollection<string>(
                (from cmd in Commands select cmd.System).
                Union(from cd in Codes select cd.System).
                Union(from docs in Documentations select docs.System).Distinct());
            Techs = new ObservableCollection<string>(
                (from cmd in Commands select cmd.Tech).
                Union(from cd in Codes select cd.Tech).
                Union(from docs in Documentations select docs.Tech).Distinct());
            Langs = new ObservableCollection<string>(
                (from cmd in Commands select cmd.Lang).
                Union(from cd in Codes select cd.Lang).
                Union(from docs in Documentations select docs.Lang).Distinct());
        }
    }
}

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
<<<<<<< HEAD
        private readonly DefaultInfoService _defaultInfoService;
=======
>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198

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
<<<<<<< HEAD

        [ObservableProperty]
        private Dictionary<string,int>? commandSystemsCount;
        [ObservableProperty]
        private Dictionary<string, int>? commandTechsCount;
        [ObservableProperty]
        private Dictionary<string, int>? commandLangsCount;
        [ObservableProperty]
        private Dictionary<string, int>? codeSystemsCount;
        [ObservableProperty]
        private Dictionary<string, int>? codeTechsCount;
        [ObservableProperty]
        private Dictionary<string, int>? codeLangsCount;
        [ObservableProperty]
        private Dictionary<string, int>? docuSystemsCount;
        [ObservableProperty]
        private Dictionary<string, int>? docuTechsCount;
        [ObservableProperty]
        private Dictionary<string, int>? docuLangsCount;
        public DataManager( CommandService commandService, 
                            CodeService codeService, 
                            DocumentationService documentationService,
                            DefaultInfoService defaultInfoService)
=======
        public DataManager( CommandService commandService, 
                            CodeService codeService, 
                            DocumentationService documentationService)
>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198
        {
            _commandService = commandService;
            _codeService = codeService;
            _documentationService = documentationService;
<<<<<<< HEAD
            _defaultInfoService = defaultInfoService;
=======

>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198

        }

        public async void PreLoadData()
        {
<<<<<<< HEAD
            Commands = new ObservableCollection<ReadUpdateDTO>(await _commandService.GetAsync());
            Codes = new ObservableCollection<ReadUpdateDTO>(await _codeService.GetAsync());
            Documentations = new ObservableCollection<ReadUpdateDTO>(await _documentationService.GetAsync());
            Systems = new ObservableCollection<string>(await _defaultInfoService.GetAllSystems());
            Techs = new ObservableCollection<string>(await _defaultInfoService.GetAllSTechs());
            Langs = new ObservableCollection<string>( await _defaultInfoService.GetAllLangs());

            CommandSystemsCount = new();
            CommandTechsCount = new();
            CommandLangsCount = new();
            CodeSystemsCount = new();
            CodeTechsCount = new();
            CodeLangsCount = new();
            DocuSystemsCount = new();
            DocuTechsCount = new();
            DocuLangsCount = new();
            foreach (var item in Systems)
            {
                var count = Commands.Where(c => c.System.Equals(item)).Count();
                if (count > 0) CommandSystemsCount.Add(item, count);
                count = Codes.Where(c => c.System.Equals(item)).Count();
                if (count > 0) CodeSystemsCount.Add(item, count);
                count = Documentations.Where(c => c.System.Equals(item)).Count();
                if (count > 0) DocuSystemsCount.Add(item, count);
            }
            foreach (var item in Techs)
            {
                var count = Commands.Where(c => c.Tech.Equals(item)).Count();
                if (count > 0) CommandTechsCount.Add(item, count); 
                count = Codes.Where(c => c.Tech.Equals(item)).Count();
                if (count > 0) CodeTechsCount.Add(item, count);
                count = Documentations.Where(c => c.Lang.Equals(item)).Count();
                if (count > 0) DocuLangsCount.Add(item, count);
            }
            foreach (var item in Langs)
            {
                var count = Commands.Where(c => c.Lang.Equals(item)).Count();
                if(count > 0) CommandLangsCount.Add(item, count); 
                count = Codes.Where(c => c.Lang.Equals(item)).Count();
                if (count > 0) CodeLangsCount.Add(item, count);
                count = Documentations.Where(c => c.Lang.Equals(item)).Count();
                if (count > 0) DocuLangsCount.Add(item, count);
            }

            OnFinishedLoadingData();
        }

        public event Action? FinishedLoadingData;
        private void OnFinishedLoadingData()
        {
            FinishedLoadingData?.Invoke();
        }

        public async Task<Guid> DeleteCommand(ReadUpdateDTO command)
        {
            this.Commands!.Remove(command);
            return (await _commandService.DeleteAsync(command.Id)).Data;
        }
        public async Task<Guid> CreateCommand(CreateDTO command)
        {
            Guid id = (await _commandService.CreateAsync(command)).Data;
            this.Commands!.Add(new ReadUpdateDTO(command,id));
            return id;
        }
        public async Task<Guid> UpdateCommand(ReadUpdateDTO command)
        {
            Guid id = (await _commandService.UpdateAsync(command)).Data;
            ReadUpdateDTO? cmd = this.Commands!.Where(c => c.Id == command.Id).FirstOrDefault();
            this.Commands!.Remove(cmd!);
            Commands.Add(command);
            return id;
=======
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
>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198
        }
    }
}

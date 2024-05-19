using CommunityToolkit.Mvvm.ComponentModel;
<<<<<<< HEAD
using CommunityToolkit.Mvvm.Input;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.WPF.Manager;
using System.Collections.ObjectModel;
using System.Windows;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class CommandPageViewModel : ObservableRecipient
    {
        //  ***** DI-Fields : DataManager *****************
        private readonly DataManager? _dataManager;

        //  ***** Observalble Property for all Commands and the current selected One
        [ObservableProperty]
        private ObservableCollection<ReadUpdateDTO>? allCommands;

        [ObservableProperty]
        private string currentDocument = string.Empty;

        //  ***** Observable Properties for Selection in the ListView containing all Commands
        [ObservableProperty]
        private ReadUpdateDTO? selectedCommand;
        partial void OnSelectedCommandChanged(ReadUpdateDTO? value)
        {
            CurrentDocument = value != null ? readText(value.Text) : string.Empty;
        }
        [ObservableProperty]
        private int? selectedIndex;

        //  ***** Bindable Property for Search-Categories
        private IEnumerable<string> categories;
        public IEnumerable<string> Categories => categories;

        //  ***** Observable Property for the Category to search
        [ObservableProperty]
        private string searchCategory = "Text/Code";
        //  ***** Observable Property for Search Text
        [ObservableProperty]
        private string searchText = string.Empty;

        //  ***** Property for Changing to/from CreateNew Mode
        [ObservableProperty]
        private bool isCreateNewActive = false;

        [ObservableProperty]
        private bool isEditEnabled = false;
        [ObservableProperty]
        private bool isNotEditEnabled = true;

        [ObservableProperty]
        private string? lastActionMessage;

        //  ***** Constructor 
        //  ***** DI - DataManager
        //  ***** Initializes SelectedIndex with 0
        //  ***** Hardcoding of FilterOptions
        public CommandPageViewModel(DataManager dataManager)
        {
            _dataManager = dataManager;
            AllCommands = _dataManager.Commands;
            SelectedIndex = 0;
            categories = new List<string>()
            {
                "Text/Code", "System", "Technology", "Language", "Description"
            };
        }
        
        //  ***** Reads the Text-Attribute of the ReadUpdateDTO
        //  ***** and converts it into inline CodeBlock for Markdown
        private string readText(string text)
        {
            if (!text.StartsWith("`"))
            {
                return $"` {text} `";
            }
            else
            {
                return text;
            }
        }

        [ObservableProperty]
        private string newCommandText = string.Empty;
        [ObservableProperty]
        private string newCommandSystem = string.Empty;
        [ObservableProperty]
        private string newCommandTech = string.Empty;
        [ObservableProperty]
        private string newCommandLang = string.Empty;
        [ObservableProperty]
        private string newCommandVersion = "1.0.0";
        [ObservableProperty]
        private string newCommandDescription = string.Empty;

        private ReadUpdateDTO EditCommandFallback = ReadUpdateDTO.Default;

        //  ***** Create a new Command *********************
        //  ***** - Shows the CreateCommandPage

        [RelayCommand]
        public void ToggleCreateNew()
        {
            IsCreateNewActive = !IsCreateNewActive;
        }
        
        [RelayCommand]
        public async Task CreateNew()
        {
            CreateDTO dto = new CreateDTO
            {
                Text = NewCommandText,
                System = NewCommandSystem,
                Tech = NewCommandTech,
                Lang = NewCommandLang,
                Version = NewCommandVersion,
                Description = NewCommandDescription
            };
            Guid id = await _dataManager!.CreateCommand(dto);
            LastActionMessage = $"Created new Command :\n {id}";
            ToggleCreateNew();
        }

        [RelayCommand]
        public void EditCurrent()
        {
            SetFallback();
            ToggleEditVisibility();
        }
        [RelayCommand]
        public async Task SaveEdit()
        {
            Guid id = await _dataManager!.UpdateCommand(SelectedCommand!);
            LastActionMessage = $"Successfully edited Command :\n {id}";
            ToggleEditVisibility();
            SelectedIndex = AllCommands.Count() - 1;
        }
        [RelayCommand]
        public void CancelEdit()
        {
            ResetSelected();
            ToggleEditVisibility();
        }

        private void ToggleEditVisibility()
        {
            IsEditEnabled = !IsEditEnabled;
            IsNotEditEnabled = !IsNotEditEnabled;
        }
        private void SetFallback()
        {
            EditCommandFallback = SelectedCommand!;
        }
        private void ResetSelected()
        {
            SelectedCommand = EditCommandFallback;
        }
        //  ***** Delete the current shown Command *********
        //  ***** - Shows a MessageBox to ensure
        //  ***** - only deletes on confirmation
        [RelayCommand]
        public async Task DeleteCurrent()
        {
            var confirmation = MessageBoxResult.No;
            if(SelectedCommand != null)
            {
                confirmation = MessageBox.Show("Are you sure ?", "Deleting Command", MessageBoxButton.YesNo);
            }
            if(confirmation == MessageBoxResult.Yes && _dataManager!.Commands != null)
            {
                Guid id = await _dataManager.DeleteCommand(SelectedCommand!);
                _dataManager.Commands.Remove(SelectedCommand!);
                AllCommands.Remove(SelectedCommand);
                LastActionMessage = $"Deleted Command :\n {id}";
                SelectedIndex = 0;
            }
        }

        [RelayCommand]
        public void SearchFor()
        {
            if (string.IsNullOrEmpty(SearchText) || string.IsNullOrEmpty(SearchCategory))
            {
                AllCommands = _dataManager.Commands; return;
            }
            switch (SearchCategory) {
                case "Text/Code":
                    AllCommands = new ObservableCollection<ReadUpdateDTO>(AllCommands.Where(c => c.Text.ToLower().Contains(SearchText.ToLower()) 
                                                                                            || SearchText.ToLower().Contains(c.Text.ToLower()))); 
                    break;
                case "System":
                    AllCommands = new ObservableCollection<ReadUpdateDTO>(AllCommands.Where(c => c.System.ToLower().Contains(SearchText.ToLower()) 
                                                                                            || SearchText.ToLower().Contains(c.System.ToLower())));
                    break;
                case "Technology":
                    AllCommands = new ObservableCollection<ReadUpdateDTO>(AllCommands.Where(c => c.Tech.ToLower().Contains(SearchText.ToLower()) 
                                                                                            || SearchText.ToLower().Contains(c.Tech.ToLower())));
                    break;
                case "Language":
                    AllCommands = new ObservableCollection<ReadUpdateDTO>(AllCommands.Where(c => c.Lang.ToLower().Contains(SearchText.ToLower()) 
                                                                                            || SearchText.ToLower().Contains(c.Lang.ToLower())));
                    break;
                case "Description":
                    AllCommands = new ObservableCollection<ReadUpdateDTO>(AllCommands.Where(c => c.Description.ToLower().Contains(SearchText.ToLower()) 
                                                                                            || SearchText.ToLower().Contains(c.Description.ToLower())));
                    break;
                default:
                    
                    break;
            }
        }
        [RelayCommand]
        public void ClearSearch()
        {
            SearchText = string.Empty;
            SearchFor();
        }
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public class CommandPageViewModel : ObservableRecipient
    {
>>>>>>> a52c645db36ba9ff1941710d4786694c0054c198
    }
}

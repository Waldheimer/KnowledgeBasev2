using CommunityToolkit.Mvvm.ComponentModel;
using KnowledgeBasev2.Domain.DTOs;
using KnowledgeBasev2.WPF.Manager;
using MdXaml;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KnowledgeBasev2.WPF.ViewModels
{
    public partial class CodePageViewModel : ObservableRecipient
    {
        private readonly DataManager _dataManager;

        public ObservableCollection<ReadUpdateDTO>? AllCodes => _dataManager.Codes;

        [ObservableProperty]
        private string currentDocument = string.Empty;

        [ObservableProperty]
        private ReadUpdateDTO? selectedCode;
        partial void OnSelectedCodeChanged(ReadUpdateDTO? value)
        {
            CurrentDocument = value != null ? readText(value.Text) : string.Empty;
        }
        [ObservableProperty]
        private int? selectedIndex;


        private IEnumerable<string> categories;
        public IEnumerable<string> Categories => categories;

        [ObservableProperty]
        private string searchText = string.Empty;

        public CodePageViewModel(DataManager dataManager)
        {
            _dataManager = dataManager;
            SelectedIndex = 0;
            categories = new List<string>()
            {
                "Text/Code", "System", "Technology", "Language", "Description"
            };
        }

        private string readText(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }
            else
            {
                return file;
            }
        }
    }
}

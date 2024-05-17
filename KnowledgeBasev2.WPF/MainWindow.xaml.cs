using CommunityToolkit.Mvvm.Messaging;
using KnowledgeBasev2.WPF.Messages;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KnowledgeBasev2.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double MainWindowWidth, MainWindowHeight;
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send<ApplicationSizeMessage>(new ApplicationSizeMessage(e.NewSize));
            //this.Title = e.NewSize.ToString();
            //if(e.WidthChanged)
            //    MainWindow.MainWindowWidth = e.NewSize.Width;
            //if(e.HeightChanged)
            //    MainWindow.MainWindowHeight = e.NewSize.Height;
        }
    }
}
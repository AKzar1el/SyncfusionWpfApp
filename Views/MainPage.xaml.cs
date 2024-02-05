using System.Windows.Controls;

using SyncfusionWpfApp.ViewModels;

namespace SyncfusionWpfApp.Views
{
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

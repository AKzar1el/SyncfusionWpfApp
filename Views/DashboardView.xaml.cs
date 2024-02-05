using Syncfusion.SfSkinManager;
using System.Windows;
using System.Windows.Controls;

namespace SyncfusionWpfApp.Views
{
    /// <summary>
    /// Interaction logic for HomeDashBoardPage.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public string themeName = App.Current.Properties["Theme"]?.ToString() != null ? App.Current.Properties["Theme"]?.ToString() : "Windows11Light";

        public DashboardView()
        {
            InitializeComponent();

            SfSkinManager.SetTheme(this, new Theme(themeName));
        }

        private void NavigationItem_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using SyncfusionWpfApp.Contracts.Services;
using SyncfusionWpfApp.Helpers;
using SyncfusionWpfApp.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace SyncfusionWpfApp.ViewModels
{
    public class ShellViewModel : Observable
    {
        private readonly INavigationService _navigationService;
        private RelayCommand _goBackCommand;
        private RelayCommand _loadedCommand;
        private RelayCommand _unloadedCommand;

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        public ICommand NewButtonCommand { get; set; }

        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NewButtonCommand = new DelegateCommand(Execute);
        }

        public void Execute(object parameter)
        {
            if (parameter != null && parameter is TabControlExt)
            {
                TabItemExt tabItemExt1 = new TabItemExt()
                {
                    Header = "New Project" + ((parameter as TabControlExt).Items.Count + 1),
                };
                
                MainPage customPage = new MainPage(new MainViewModel());
                Frame customDesignPageFrame = new Frame();
                customDesignPageFrame.Content = customPage;
                tabItemExt1.Content = customDesignPageFrame;

                (parameter as TabControlExt).Items.Add(tabItemExt1);
            }
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, string viewModelName)
            => GoBackCommand.OnCanExecuteChanged();
    }
}
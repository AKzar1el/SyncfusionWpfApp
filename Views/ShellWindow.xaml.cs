﻿using System.Collections.ObjectModel;
using System.Windows.Controls;

using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

using SyncfusionWpfApp.Contracts.Views;
using SyncfusionWpfApp.ViewModels;

namespace SyncfusionWpfApp.Views
{
    public partial class ShellWindow : ChromelessWindow, IShellWindow
    {
        public static Border _border=null;
        public string themeName = App.Current.Properties["Theme"]?.ToString()!= null? App.Current.Properties["Theme"]?.ToString(): "Windows11Light";

        public ShellWindow(ShellViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
			
			SfSkinManager.SetTheme(this, new Theme(themeName));
        }

        public Frame GetNavigationFrame()
            => shellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
	public class MyObservableCollection : ObservableCollection<object> { }
}

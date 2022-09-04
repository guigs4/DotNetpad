using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using DotNetpadUI.FileDialogs;
using Engine.Services;
using Engine.ViewModels;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private readonly DataSession _dataSession;

        #region Event Delegates
        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            CacheService.CreateDefaultDirectories();
            _dataSession = new();
            _dataSession.LoadTabsFromCache();
            DataContext = _dataSession.OpenTabs;
            
        }

        public void OnClick_SaveToCache(object sender, RoutedEventArgs e)
        {
            _dataSession.SaveAllTabs();
        }

        public void OnClick_AddTab(object sender, RoutedEventArgs e)
        {
            int NewTabIndex = _dataSession.OpenTabs.Count;
            _dataSession.AddEmptyTab(NewTabIndex);
            TabControl.SelectedItem = _dataSession.OpenTabs[^1];
        }

        public void OnClick_CloseCurrentTab(object sender, RoutedEventArgs e)
        {
            int selectedTab = TabControl.SelectedIndex;
            _dataSession.RemoveTab(selectedTab);
            _dataSession.ReorderTabIndex();
        }

        public void OnClick_SaveFileDialog(object sender, RoutedEventArgs e)
        {
            int selectedTab = TabControl.SelectedIndex;
            string tabContent = _dataSession.OpenTabs[selectedTab].Content;
            SaveFileDialogWindow.ExportFile(MainUI, tabContent);
        }

        public async void OnClick_OpenFileDialog(object sender, RoutedEventArgs e)
        {
            await OpenFileDialogWindow.OpenFiles(MainUI, _dataSession);
            TabControl.SelectedItem = _dataSession.OpenTabs[^1];
        }

    }
}

using Avalonia.Controls;
using Avalonia.Interactivity;
using DotNetpadUI.FileDialogs;
using DotNetpadUI.Shared;
using Engine.ViewModels;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private IDataSessionVM _dataSession;
        private IUserPreferencesVM _userPreferences; //TODO: Extract interface

        public MainWindow() //exists solely for the Designer
        {
            InitializeComponent();
        }

        public MainWindow(IDataSessionVM dataSession, IUserPreferencesVM userPreferences)
        {
            InitializeComponent();
            _dataSession = dataSession;
            _userPreferences = userPreferences;
            _dataSession.Initialize();
            DataContext = _dataSession;
            this.UpdateInterface(_userPreferences.CurrentUserPreferences);
        }

        public void OnClick_SaveToData(object sender, RoutedEventArgs e)
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
            string? tabContent = _dataSession.OpenTabs[selectedTab].Content;
            SaveFileDialogWindow.ExportFile(MainUI, tabContent);
        }

        public async void OnClick_OpenFileDialog(object sender, RoutedEventArgs e)
        {
            await OpenFileDialogWindow.OpenFiles(MainUI, _dataSession);
            TabControl.SelectedItem = _dataSession.OpenTabs[^1];
        }

        public void OnClick_OpenPreferencesWindow(object sender, RoutedEventArgs e)
        {
            UserPreferences userPreferences = new(_userPreferences);
            userPreferences.Show(MainUI);
        }
    }
}

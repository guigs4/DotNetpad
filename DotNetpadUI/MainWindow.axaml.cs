using Avalonia.Controls;
using Avalonia.Interactivity;
using DotNetpadUI.FileDialogs;
using Engine.ViewModels;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private readonly IDataSession _dataSession;

        #region Event Delegates

        #endregion

        public MainWindow() //exists solely for the Designer
        {
            InitializeComponent();
        }

        public MainWindow(IDataSession dataSession)
        {
            InitializeComponent();
            _dataSession = dataSession;
            _dataSession.Initialize();
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

        public async void OnClick_OpenPreferencesWindow(object sender, RoutedEventArgs e)
        {
            UserPreferences userPreferences = new();
            userPreferences.Show(MainUI);
        }
    }
}

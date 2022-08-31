using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Engine.Services;
using Engine.ViewModels;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private DataSession _dataSession;

        #region Event Delegates

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _dataSession = new();
            _dataSession.AddEmptyTab(0);
            DataContext = _dataSession.OpenTabs;
        }

        public void OnClick_SaveToCache(object sender, RoutedEventArgs e)
        {
            foreach (var tab in _dataSession.OpenTabs)
            {
                CacheService.SaveTextBoxData(tab.Id, tab.Content);
            }
        }

        public void OnClick_AddTab(object sender, RoutedEventArgs e)
        {
            int NewTabIndex = _dataSession.OpenTabs.Count;
            _dataSession.AddEmptyTab(NewTabIndex);
        }

        public void OnGotFocus_SetTab(object sender, GotFocusEventArgs e)
        {
            _dataSession.CurrentTabTextBox = sender;
            e.Handled = true;
        }

        public void OnClick_CloseCurrentTab(object sender, RoutedEventArgs e)
        {
            int selectedTab = TabControl.SelectedIndex;
            _dataSession.RemoveTab(selectedTab);
            _dataSession.ReorderTabIndex();
        }
    }
}

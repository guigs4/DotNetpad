using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Engine.Services;
using Engine.ViewModels;

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
        }

        public void OnClick_CloseCurrentTab(object sender, RoutedEventArgs e)
        {
            int selectedTab = TabControl.SelectedIndex;
            _dataSession.RemoveTab(selectedTab);
            _dataSession.ReorderTabIndex();
        }
    }
}

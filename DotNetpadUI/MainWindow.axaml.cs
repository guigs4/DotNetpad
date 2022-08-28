using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Engine.ViewModels;
using Engine.Services;

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
            _dataSession.AddEmptyTab();
            DataContext = _dataSession.OpenTabs;
        }

        public void OnClick_SaveToCache(object sender, RoutedEventArgs e)
        {
            TextBox currentTab = _dataSession.CurrentTab as TextBox;
            CacheService.SaveTextBoxData(currentTab.Text);
        }


        public void OnClick_AddTab(object sender, RoutedEventArgs e)
        {
            _dataSession.AddEmptyTab();
        }

        public void OnGotFocus_SetTab(object sender, GotFocusEventArgs e)
        {
            _dataSession.CurrentTab = sender;
        }
    }
}

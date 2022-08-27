using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Engine.ViewModels;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private DataSession _dataSession;
        private int tabCount { get => _dataSession.OpenTabs.Count; }

        #region Event Delegates

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _dataSession = new();
            _dataSession.OpenTabs.Add(new(2,"tab 2"));
            DataContext = _dataSession.OpenTabs;
        }

        public void OnClick_SaveToCache(object sender, RoutedEventArgs e)
        {
            TextBox currentTab = _dataSession.CurrentTab as TextBox;
            _dataSession.SaveTextBoxData(currentTab.Text);
        }


        public void OnClick_AddTab(object sender, RoutedEventArgs e)
        {
            int newIndex = tabCount + 1;
            _dataSession.OpenTabs.Add(new(newIndex, $"Tab {newIndex}"));
        }

        public void OnGotFocus_SetTab(object sender, GotFocusEventArgs e)
        {
            _dataSession.CurrentTab = sender;
        }
    }
}

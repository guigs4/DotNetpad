using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Engine.ViewModels;
using Engine.Services;
using Avalonia.Collections;
using Avalonia.LogicalTree;
using System.Collections.Generic;

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
            TextBox currentTabTextBox = _dataSession.CurrentTabTextBox as TextBox;
            CacheService.SaveTextBoxData(currentTabTextBox.Text);
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

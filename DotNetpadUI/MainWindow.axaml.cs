using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
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
        //public delegate void ClickEventHandler(object sender, RoutedEventArgs e);

        //public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
        //    RoutedEvent.Register<Button,RoutedEventArgs>(nameof(Click), RoutingStrategies.Bubble);

        //// Provide CLR accessors for the event
        //public event EventHandler<RoutedEventArgs> Click
        //{
        //    add => AddHandler(ClickEvent, value);
        //    remove => RemoveHandler(ClickEvent, value);
        //}
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
        }

        public void OnClick_CloseCurrentTab(object sender, RoutedEventArgs e)
        {
            int selectedTab = TabControl.SelectedIndex;
            _dataSession.RemoveTab(selectedTab);
            _dataSession.ReorderTabIndex();
        }

        public void OnClick_SaveDialog(object sender, RoutedEventArgs e)
        {
            testAsync();

            //var saveDialog = new SaveFileDialog();

            //saveDialog.ShowAsync(MainUI);
        }

        private async Task testAsync()
        {
            var dlg = new OpenFileDialog();
            dlg.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } });
            dlg.AllowMultiple = true;

            var result = await dlg.ShowAsync(MainUI);
            if (result != null)
            {
                string[] fileNames = result;
                var sb = new StringBuilder();
                int indexTest = _dataSession.OpenTabs.Count -1;
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        _dataSession.OpenTabs.Add(new(indexTest, fileName, CacheService.LoadTextBoxData(fileName), false));
                        indexTest++;
                    }
                    catch (Exception ex)
                    {
                        string text = string.Format("Error: {0}\n", ex.Message);
                        sb.Append(text);
                    }
                }
            }
        }
    }
}

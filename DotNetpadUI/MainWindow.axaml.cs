using Avalonia.Controls;
using Avalonia.Interactivity;
using Engine.ViewModels;

namespace DotNetpadUI
{
    public partial class MainWindow : Window
    {
        private DataSession _dataSession;
        public MainWindow()
        {
            InitializeComponent();
            _dataSession = new();
            TextBox.Text = _dataSession.LoadTextBoxData();
        }

        public void OnClick_SaveToCache(object sender, RoutedEventArgs e)
        {
            _dataSession.SaveTextBoxData(TextBox.Text);
        }
    }
}

using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        public UserPreferences()
        {
            InitializeComponent();
        }

        public void OnClick_Apply(object sender, RoutedEventArgs e)
        {
            UserPreferencesUI.Close();
        }

        public void OnClick_Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}

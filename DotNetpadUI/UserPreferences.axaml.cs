using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Engine.ViewModels;
using System.Linq;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        public UserPreferences()
        {
            InitializeComponent();
            
            var fontComboBox = this.Find<ComboBox>("fontComboBox");
            fontComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames().Select(x => new FontFamily(x));
            fontComboBox.SelectedIndex = 0;
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

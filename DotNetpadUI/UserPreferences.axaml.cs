using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Engine.Models;
using Engine.ViewModels;
using System.Linq;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        private readonly UserPreferencesModel _userPreferences;

        public UserPreferences()
        {
            InitializeComponent();
        }

        public UserPreferences(UserPreferencesModel userPreferences)
        {
            InitializeComponent();
            _userPreferences = userPreferences;
        }

        public void OnClick_Apply(object sender, RoutedEventArgs e)
        {
        }

        public void OnClick_Cancel(object sender, RoutedEventArgs e)
        {
            UserPreferencesUI.Close();
        }

        public void InitialSetup()
        {
            //combobox broken on EndeavourOS Plasma
            //Works on XFCE but it's very very slow 
            var fontComboBox = this.Find<ComboBox>("fontComboBox"); 
            fontComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames(true).Select(x => new FontFamily(x));
            fontComboBox.SelectedIndex = 0;
        }

        public void OnClick_SetLightTheme(object sender, RoutedEventArgs e)
        {
            //Background = _userPreferences.BackgroundColor;
            ((MainWindow)Owner).SetPreferences("#FFFFFF", "#000000");
        }
        public void OnClick_SetDarkTheme(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Owner).SetPreferences("#1E1E1E", "#FFFFFF");
        }
    }
}

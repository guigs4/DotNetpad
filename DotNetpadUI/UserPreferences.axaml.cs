using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Engine.Models;
using System.Linq;
using DotNetpadUI.Shared;

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
            this.UpdateInterface(_userPreferences);
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
            _userPreferences.BackgroundColor = "#EBEBEB";
            _userPreferences.ForegroundColor = "#000000";
            this.UpdateInterface(_userPreferences);
            ((MainWindow)Owner).UpdateInterface(_userPreferences);
        }
        public void OnClick_SetDarkTheme(object sender, RoutedEventArgs e)
        {
            _userPreferences.BackgroundColor = "#1E1E1E";
            _userPreferences.ForegroundColor = "#FFFFFF";
            this.UpdateInterface(_userPreferences);
            ((MainWindow)Owner).UpdateInterface(_userPreferences);
        }
    }
}

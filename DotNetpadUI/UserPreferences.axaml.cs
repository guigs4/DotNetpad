using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DotNetpadUI.Shared;
using Engine.Models;
using Engine.Services;
using System.Linq;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        private readonly UserPreferencesModel _tempUserPreferences;
        private UserPreferencesModel _mainUserPreferences;

        public UserPreferences()
        {
            InitializeComponent();
        }

        public UserPreferences(UserPreferencesModel userPreferences)
        {
            InitializeComponent();
            _tempUserPreferences = (UserPreferencesModel)userPreferences.Clone();
            _mainUserPreferences = userPreferences;
            this.UpdateInterface(_mainUserPreferences);
        }

        public void OnClick_Apply(object sender, RoutedEventArgs e)
        {
            UserPreferencesIOService.SavePreferences(_tempUserPreferences);
            UserPreferencesUI.Close();
        }

        public void OnClick_Cancel(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Owner).UpdateInterface(_mainUserPreferences);
            this.UpdateInterface(_mainUserPreferences);
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
            _tempUserPreferences.BackgroundColor = "#EBEBEB";
            _tempUserPreferences.ForegroundColor = "#000000";
            this.UpdateInterface(_tempUserPreferences);
            ((MainWindow)Owner).UpdateInterface(_tempUserPreferences);

        }
        public void OnClick_SetDarkTheme(object sender, RoutedEventArgs e)
        {
            _tempUserPreferences.BackgroundColor = "#1E1E1E";
            _tempUserPreferences.ForegroundColor = "#FFFFFF";
            this.UpdateInterface(_tempUserPreferences);
            ((MainWindow)Owner).UpdateInterface(_tempUserPreferences);
        }

    }
}

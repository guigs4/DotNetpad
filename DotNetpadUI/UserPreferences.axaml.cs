using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DotNetpadUI.Shared;
using Engine.Models;
using Engine.ViewModels;
using System.Linq;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        private IUserPreferencesVM _userPreferencesVM;
        private readonly UserPreferencesModel _tempUserPreferences;
        private UserPreferencesModel _mainUserPreferences;

        public UserPreferences()
        {
            InitializeComponent();
        }

        public UserPreferences(IUserPreferencesVM userPreferencesVM)
        {
            InitializeComponent();
            _userPreferencesVM = userPreferencesVM;
            _mainUserPreferences = userPreferencesVM.CurrentUserPreferences;
            _tempUserPreferences = (UserPreferencesModel)_mainUserPreferences.Clone();
            this.UpdateInterface(_mainUserPreferences);
        }

        public void OnClick_Apply(object sender, RoutedEventArgs e)
        {
            _userPreferencesVM.SetGlobalPreferences(_tempUserPreferences);
            _userPreferencesVM.SavePreferences();
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

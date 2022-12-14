using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DotNetpadUI.Shared;
using Engine.Models;
using Engine.ViewModels;
using System.Linq;
using Avalonia.Input;

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
            InitialSetup();
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
            UpdateAllInterfaces(_mainUserPreferences);
            UserPreferencesUI.Close();
        }

        public void InitialSetup()
        {
            //combobox broken on EndeavourOS Plasma
            //Works on XFCE but it's very very slow 
            var fontComboBox = this.Find<ComboBox>("FontComboBox");
            fontComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames(true).Select(x => new FontFamily(x));
            fontComboBox.SelectedItem = new FontFamily(_tempUserPreferences.Font);
        }

        public void OnClick_SetLightTheme(object sender, RoutedEventArgs e)
        {
            _tempUserPreferences.BackgroundColor = "#EBEBEB";
            _tempUserPreferences.ForegroundColor = "#000000";
            UpdateAllInterfaces(_tempUserPreferences);

        }
        public void OnClick_SetDarkTheme(object sender, RoutedEventArgs e)
        {
            _tempUserPreferences.BackgroundColor = "#1E1E1E";
            _tempUserPreferences.ForegroundColor = "#FFFFFF";
            UpdateAllInterfaces(_tempUserPreferences);
        }

        private void OnPointerEnter_FontEntry(object? sender, PointerEventArgs e)
        {
            _tempUserPreferences.Font = ((TextBlock)sender).Text;
            UpdateAllInterfaces(_tempUserPreferences);
        }

        private void OnSelectionChanged_FontComboBox(object? sender, SelectionChangedEventArgs e)
        {
            _tempUserPreferences.Font = ((ComboBox)sender).SelectedItem.ToString();
            UpdateAllInterfaces(_tempUserPreferences);
        }

        private void UpdateAllInterfaces(UserPreferencesModel preferences)
        {
            this.UpdateInterface(preferences);
            ((MainWindow)Owner)?.UpdateInterface(preferences);
        }
    }
}

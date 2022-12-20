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
            var fontComboBox = this.Find<ComboBox>("FontComboBox");
            fontComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames(true).Select(x => new FontFamily(x));
            fontComboBox.SelectedItem = new FontFamily(_tempUserPreferences.Font); //TODO: Check if Font is empty
        }

        public void OnClick_SetTheme(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            switch (button.Name)
            {
                    case "Light":
                        _tempUserPreferences.BackgroundColor = "#FCFCDC";
                        _tempUserPreferences.ForegroundColor = "#000000";
                        break;
                    case "LightHC":
                        _tempUserPreferences.BackgroundColor = "#ffffff";
                        _tempUserPreferences.ForegroundColor = "#000000";
                        break;
                    case "Dark":
                        _tempUserPreferences.BackgroundColor = "#1E1E1E";
                        _tempUserPreferences.ForegroundColor = "#FFFFFF";
                        break;
                    case "DarkHC":
                        _tempUserPreferences.BackgroundColor = "#000000";
                        _tempUserPreferences.ForegroundColor = "#FFFFFF";
                        break;
            }
            
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

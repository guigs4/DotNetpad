using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Engine.ViewModels;
using System.Linq;

namespace DotNetpadUI
{
    public partial class UserPreferences : Window
    {
        private readonly IDataSession _dataSession;
        public UserPreferences()
        {
            InitializeComponent();
        }

        public UserPreferences(IDataSession dataSession)
        {
            InitializeComponent();
            InitialSetup();
            _dataSession = dataSession; //could be assigned directly but just in case
            DataContext = _dataSession.CurrentUserPreferences;
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
            _dataSession.CurrentUserPreferences.BackgroundColor = "#FFFFFF";
            _dataSession.CurrentUserPreferences.ForegroundColor= "#000000";
        }
        public void OnClick_SetDarkTheme(object sender, RoutedEventArgs e)
        {
            _dataSession.CurrentUserPreferences.BackgroundColor = "#000000";
            _dataSession.CurrentUserPreferences.ForegroundColor = "#FFFFFF";

        }
    }
}

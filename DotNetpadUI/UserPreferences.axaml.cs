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
            DataContext = _dataSession;
        }

        public void OnClick_Apply(object sender, RoutedEventArgs e)
        {
            UserPreferencesUI.Close();
        }

        public void OnClick_Cancel(object sender, RoutedEventArgs e)
        {

        }

        public void InitialSetup()
        {
            var fontComboBox = this.Find<ComboBox>("fontComboBox");
            fontComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames().Select(x => new FontFamily(x));
            fontComboBox.SelectedIndex = 0;
        }
    }
}

using Engine.Models;
using IOLib;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
	public class DataSession
	{
		private const string SAVE_FILE_PATH = "cache\\data.txt";

		public ObservableCollection<TextBoxModel> OpenTabs { get; set; }

		public object CurrentTab { get; set; } = new();

		public DataSession()
		{
			if (OpenTabs == null)
			{
				OpenTabs = new();
				OpenTabs.Add(new TextBoxModel(1, "Tab 1"));
			}
		}


		public void SaveTextBoxData(string text)
		{
			IO.SaveStringToFile(SAVE_FILE_PATH, text);
		}

		public string LoadTextBoxData()
		{
			if (File.Exists(SAVE_FILE_PATH))
			{
				return IO.LoadStringFromFile(SAVE_FILE_PATH); 
			}
			else
			{
				return "";
			}
		}
	}
}

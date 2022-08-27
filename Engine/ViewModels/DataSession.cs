using Engine.Models;
using IOLib;

namespace Engine.ViewModels
{
	public class DataSession
	{
		private const string SAVE_FILE_PATH = "cache\\data.txt";
		public TextBoxModel CurrentData { get; set; } = new();

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

using Engine.Models;
using IOLib;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
	public class DataSession
	{
		public ObservableCollection<TextBoxModel> OpenTabs { get; set; }
        private int tabCount { get => OpenTabs.Count; }
        public object CurrentTab { get; set; } = new();

		public DataSession()
		{
			if (OpenTabs == null)
			{
				OpenTabs = new();
			}
		}

		public void AddEmptyTab()
		{
			int newID = tabCount+1;
			OpenTabs.Add(new(newID,$"Tab {newID}"));
		}
	}
}

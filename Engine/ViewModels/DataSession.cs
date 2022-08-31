using Engine.Models;
using System.Collections.ObjectModel;
using Engine.Services;

namespace Engine.ViewModels
{
	public class DataSession
	{
		public ObservableCollection<TabModel> OpenTabs { get; set; } //TODO: Move to Factory
		public int TabIndexMax { get; set; } = 0;
        public object CurrentTab { get; set; } = new();
		public object CurrentTabTextBox { get; set; }

		public DataSession()
		{
			OpenTabs ??= new(); //if 'null' create new
		}

		public void AddEmptyTab(int newTabIndex)
		{
			OpenTabs.Add(new(newTabIndex));
		}

		public void RemoveTab(int id)
		{
			var tabToRemove = OpenTabs.Where(tab => tab.Id == id).First();
			OpenTabs.Remove(tabToRemove);
		}

		public void ReorderTabIndex()
		{
			var currentTabList = OpenTabs;
			int newId = 0;

			foreach (var tab in currentTabList)
			{
				tab.Id = newId;

                newId++;
			}
		}

		public void LoadExistingTabs()
		{
			string[] files = Directory.GetFiles("cache\\", "data *?.txt");

			if (files == null)
			{
				AddEmptyTab(0);
				return;
			}
			
			int id = 0;

			foreach (string file in files)
			{
				string content = CacheService.LoadTextBoxData(file);

                OpenTabs.Add(new(id, "Tab", content));

				id++;
			}
		}
	}
}

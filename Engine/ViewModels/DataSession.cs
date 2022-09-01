using Engine.Models;
using System.Collections.ObjectModel;
using Engine.Services;

namespace Engine.ViewModels
{
	public class DataSession
	{
		public ObservableCollection<TabModel> OpenTabs { get; set; } //TODO: Move to Factory
		
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

		public void SaveAllTabs()
		{
            foreach (var tab in OpenTabs.Where(t=> t.IsInternal))
            {
                CacheService.SaveTextBoxData(tab.Id, tab.Content);
            }
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

		public void LoadTabsFromCache()
		{
			string[] files = CacheService.GetAllExistingCacheFiles();

			if (!files.Any())
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

using Engine.Models;
using System.Collections.ObjectModel;
using Engine.Services;

namespace Engine.ViewModels
{
	public class DataSession
	{
		public ObservableCollection<TabModel> OpenTabs { get; set; } //TODO: Move to Factory
		private int _id;

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
			_id = 0;

			string[] files = CacheService.GetAllExistingCacheFiles();

			if (!files.Any())
			{
				AddEmptyTab(0);
				return;
			}
			
			

			foreach (string file in files)
			{
				string content = CacheService.LoadTextBoxData(file);

                OpenTabs.Add(new(_id, "Tab", content));

				_id++;
			}
		}
	}
}

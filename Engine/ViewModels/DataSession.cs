using Engine.Models;
using IOLib;
using System;
using System.Collections.ObjectModel;

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
			if (OpenTabs == null)
			{
				OpenTabs = new();
			}
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
	}
}

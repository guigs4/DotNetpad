﻿using Engine.Models;
using Engine.Services;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
	public class DataSession
	{
		private Timer timer;
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
			int id = 0;
            foreach (var tab in OpenTabs.Where(t=> t.IsInternal))
            {
                CacheService.SaveTextBoxData(id, tab.Content);
				id++;
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
			int id = 0;

			string[] files = CacheService.GetAllExistingCacheFiles();

			if (!files.Any())
			{
				AddEmptyTab(0);
				return;
			}
			
			foreach (string file in files)
			{
				string content = CacheService.LoadTextBoxData(file);

                OpenTabs.Add(new(id, "Tab", content));

				id++;
			}
		}

		public void InitializeTimer(int intervalInSeconds)
		{
			int interval = intervalInSeconds * 1000;
            timer = new Timer(new TimerCallback(TickTimer), null, interval, interval);
		}

		private void TickTimer(object state)
		{
			SaveAllTabs();
		}

		public void ChangeTimer(int intervalInSeconds)
		{
			int interval = intervalInSeconds * 1000;
			timer.Change(interval, interval);
		}
	}
}

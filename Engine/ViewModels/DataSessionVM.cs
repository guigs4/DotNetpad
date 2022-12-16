using Engine.Models;
using Engine.Services;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
	public class DataSessionVM : ReactiveObject, IDataSessionVM
	{
		private Timer _timer;
		private const string DATA_PATH = "data/data.json";
		public ObservableCollection<TabModel> OpenTabs { get; set; } //TODO: Move to Factory

		public DataSessionVM()
		{
			OpenTabs ??= new(); //if 'null' create new
		}

		public void Initialize() //Maybe move into the ctor
		{
			LoadTabsFromDisk();
			InitializeTimer(10000);
			this.RaisePropertyChanged();
		}

		public void AddEmptyTab(int newTabIndex)
		{
			OpenTabs.Add(new(newTabIndex));
		}

		public void RemoveTab(int id)
		{
			var tabToRemove = OpenTabs.First(tab => tab.Id == id);
			OpenTabs.Remove(tabToRemove);
		}

		public void SaveAllTabs()
		{
			TabDataIOService.SaveTabData(DATA_PATH, OpenTabs);
			// int id = 0;
			// foreach (var tab in OpenTabs.Where(t => t.IsInternal))
			// {
			// 	TabDataIOService.SaveTextBoxData(id, tab.Content);
			// 	id++;
			// }
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

		public void LoadTabsFromDisk()
		{
			int id = 0;

			string[] files = DiskIOService.GetAllExistingDataFiles();

			if (!files.Any())
			{
				AddEmptyTab(0);
				return;
			}

			foreach (string file in files)
			{
				string content = TabDataIOService.LoadTextBoxData(file);

				OpenTabs.Add(new(id, "Tab", content));

				id++;
			}
		}

		public void InitializeTimer(int intervalInMs)
		{
			_timer = new Timer(new TimerCallback(TickTimer), null, intervalInMs, intervalInMs);
		}

		private void TickTimer(object state)
		{
			SaveAllTabs();
		}

		public void ChangeTimer(int intervalInMs)
		{
			_timer.Change(intervalInMs, intervalInMs);
		}


	}
}

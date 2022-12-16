using Engine.Models;
using Engine.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Text.Json;

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
			InitializeTimer(60000);
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
			if (!File.Exists(DATA_PATH))
			{
				AddEmptyTab(0);
				return;
			}

			var json = File.ReadAllText(DATA_PATH);
			
			OpenTabs = JsonSerializer.Deserialize<ObservableCollection<TabModel>>(json)!;
		}

		public void InitializeTimer(int intervalInMs)
		{
			_timer = new Timer(TickTimer, null, intervalInMs, intervalInMs);
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

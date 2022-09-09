using Engine.Models;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public interface IDataSession
    {
        ObservableCollection<TabModel> OpenTabs { get; set; }

        void AddEmptyTab(int newTabIndex);
        void ChangeTimer(int intervalInMs);
        void Initialize();
        void InitializeTimer(int intervalInMs);
        void LoadTabsFromCache();
        void RemoveTab(int id);
        void ReorderTabIndex();
        void SaveAllTabs();
    }
}
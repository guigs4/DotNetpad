﻿using Engine.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public interface IDataSession : INotifyPropertyChanged
    {
        ObservableCollection<TabModel> OpenTabs { get; set; }
        UserPreferencesModel CurrentUserPreferences { get; set; }

        void AddEmptyTab(int newTabIndex);
        void ChangeTimer(int intervalInMs);
        void Initialize();
        void InitializeTimer(int intervalInMs);
        void LoadTabsFromDisk();
        void RemoveTab(int id);
        void ReorderTabIndex();
        void SaveAllTabs();
    }
}
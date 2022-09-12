using Engine.Models;
using Engine.Services;

namespace Engine.ViewModels
{
    public class UserPreferencesVM : IUserPreferencesVM
    {
        public UserPreferencesModel CurrentUserPreferences { get; set; }

        public UserPreferencesVM()
        {
            LoadUserPreferencesFromDisk();
        }

        public void LoadUserPreferencesFromDisk()
        {
            UserPreferencesIOService.CheckIfUserPrefsExists();
            CurrentUserPreferences = UserPreferencesIOService.DeserializePreferencesObject();
        }

        public void SavePreferences()
        {
            CurrentUserPreferences.SavePreferences();
        }

        public void SetGlobalPreferences(UserPreferencesModel preferencesToSet)
        {
            CurrentUserPreferences = preferencesToSet;
        }

    }
}

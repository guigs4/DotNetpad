using Engine.Models;
using Engine.Services;

namespace Engine.ViewModels
{
    public class UserPreferencesVM
    {
        public UserPreferencesModel CurrentUserPreferences{ get; set; }


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

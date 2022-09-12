using Engine.Models;

namespace Engine.ViewModels
{
    public interface IUserPreferencesVM
    {
        UserPreferencesModel CurrentUserPreferences { get; set; }

        void LoadUserPreferencesFromDisk();
        void SavePreferences();
        void SetGlobalPreferences(UserPreferencesModel preferencesToSet);
    }
}
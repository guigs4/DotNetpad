using Engine.Models;
using System.Reflection;
using System.Text.Json;
using static Engine.Shared.SharedJsonSerializerOptions;

namespace Engine.Services
{
    public static class UserPreferencesIOService
    {
        private const string _preferencesPath = "config/preferences.json";
        public static void SavePreferences(this UserPreferencesModel userPreferences)
        {
            string jsonString = SerializePreferencesObject(userPreferences);
            DiskIOService.SaveStringToFile(_preferencesPath, jsonString);
        }

        public static string SerializePreferencesObject(UserPreferencesModel userPreferencesModel)
        {
            return JsonSerializer.Serialize(userPreferencesModel, UseSharedJsonSerializerOptions());
        }

        public static UserPreferencesModel DeserializePreferencesObject()
        {
            string jsonString = DiskIOService.LoadStringFromFile("config/preferences.json");
            return JsonSerializer.Deserialize<UserPreferencesModel>(jsonString)!;
        }

        public static void CheckIfUserPrefsExists()
        {
            if (!File.Exists(_preferencesPath))
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames().Single(str=> str.EndsWith("DefaultUserPreferences.json"));
                using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
                using StreamReader reader = new(stream!);
                DiskIOService.SaveStringToFile("config/preferences.json", reader.ReadToEnd());
            }
        }
    }
}

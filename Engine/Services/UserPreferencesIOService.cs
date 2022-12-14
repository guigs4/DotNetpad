using Engine.Models;
using System.Reflection;
using System.Text.Json;
using static Engine.Shared.SharedJsonSerializerOptions;

namespace Engine.Services
{
    public static class UserPreferencesIOService
    {
        private const string _preferencesPath = "data/preferences.json";
        public static void SavePreferences(UserPreferencesModel userPreferences)
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
            string jsonString = DiskIOService.LoadStringFromFile(_preferencesPath);
            return JsonSerializer.Deserialize<UserPreferencesModel>(jsonString)!;
        }

        public static void CheckIfUserPrefsExists()
        {
            if (!File.Exists(_preferencesPath))
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("DefaultUserPreferences.json"));
                using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
                using StreamReader reader = new(stream!);
                DiskIOService.SaveStringToFile(_preferencesPath, reader.ReadToEnd());
            }
        }
    }
}

using Engine.Models;
using System.Text.Json;
using static Engine.Shared.SharedJsonSerializerOptions;

namespace Engine.Services
{
    public static class UserPreferencesIOService
    {
        public static string SerializePreferencesObject(UserPreferencesModel userPreferencesModel)
        {
            return JsonSerializer.Serialize(userPreferencesModel, UseSharedJsonSerializerOptions()); 
        }
        public static void DeserializePreferencesObject(ref UserPreferencesModel userPreferencesModel, string jsonString)
        {
            userPreferencesModel = JsonSerializer.Deserialize<UserPreferencesModel>(jsonString)!; 
        }
    }
}

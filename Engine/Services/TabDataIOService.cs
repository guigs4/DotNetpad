using System.Text.Json;
using Engine.Models;
using static Engine.Shared.SharedJsonSerializerOptions;
using static Engine.Services.DiskIOService;

namespace Engine.Services
{
    public static class TabDataIOService
    {
        public static void SaveTabData(string path, IEnumerable<TabModel> tabList)
        {
            var jsonToSave = JsonSerializer.Serialize(tabList, UseSharedJsonSerializerOptions());
            SaveStringToFile(path, jsonToSave);
        }

        public static void SaveTextBoxData(string path, string content)
        {
            DiskIOService.SaveStringToFile(path, content);
        }

        public static void SaveTextBoxData(int id, string content)
        {
            DiskIOService.SaveStringToFile($"data/data {id}.txt", content);
        }

        public static string LoadTextBoxData(string path)
        {
            if (File.Exists(path))
            {
                return DiskIOService.LoadStringFromFile(path);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}

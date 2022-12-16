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
            SaveStringToFile(path, content);
        }

        public static string LoadTextBoxData(string path)
        {
            //No idea why I did it like this, seems redundant
            if (File.Exists(path))
            {
                return LoadStringFromFile(path);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}

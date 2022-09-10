using System.Text.Json;

namespace Engine.Shared
{
    public static class SharedJsonSerializerOptions
    {
        //Just after I finished writing this I realized it violates YAGNI. D:
        public static JsonSerializerOptions UseSharedJsonSerializerOptions()
        {
            return new JsonSerializerOptions { WriteIndented = true };
        }
    }
}

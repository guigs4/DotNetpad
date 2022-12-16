namespace Engine.Services
{
    public static class DiskIOService
    {
        public static void CreateDefaultDirectories()
        {
            Directory.CreateDirectory("data/");
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public static void SaveStringToFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static string LoadStringFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}

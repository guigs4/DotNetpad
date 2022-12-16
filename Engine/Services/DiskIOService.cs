namespace Engine.Services
{
    public static class DiskIOService
    {
        public static string[] GetAllExistingDataFiles()
        {
            string[] files = Directory.GetFiles("data/", "data *?.txt");

            return files;
        }

        public static void CreateDefaultDirectories()
        {
            //no need to manually check if directories exist as the CreateDirectory() method already does it
            Directory.CreateDirectory("data/");
            Directory.CreateDirectory("config/");
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

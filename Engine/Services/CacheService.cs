using IOLib;

namespace Engine.Services
{
	public static class CacheService
	{
        private const string SAVE_FILE_PATH = "cache/data.txt";

        public static void SaveTextBoxData(string text)
        {
            IO.SaveStringToFile(SAVE_FILE_PATH, text);
        }

        public static void SaveTextBoxData(int id, string content)
        {
            IO.SaveStringToFile($"cache/data {id}.txt",content);
        }

        public static string LoadTextBoxData()
        {
            if (File.Exists(SAVE_FILE_PATH))
            {
                return IO.LoadStringFromFile(SAVE_FILE_PATH);
            }
            else
            {
                return "";
            }
        }

        public static string LoadTextBoxData(string path)
        {
            if (File.Exists(path))
            {
                return IO.LoadStringFromFile(path);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static string[] GetAllExistingCacheFiles()
        {
            return Directory.GetFiles("cache/", "data *?.txt");
        }

        public static void CreateDefaultDirectories()
        {
            Directory.CreateDirectory("cache/");
            //TODO: Add the config directory
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }
}

using IOLib;

namespace Engine.Services
{
	public static class CacheService
	{
        private const string SAVE_FILE_PATH = "cache\\data.txt";

        public static void SaveTextBoxData(string text)
        {
            IO.SaveStringToFile(SAVE_FILE_PATH, text);
        }

        public static void SaveTextBoxData(int id, string content)
        {
            IO.SaveStringToFile($"cache\\data {id}.txt",content);
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
    }
}

namespace Engine.Services
{
    public static class TabDataIOService
    {

        public static void SaveTextBoxData(string path, string content)
        {
            DiskIOService.SaveStringToFile(path, content);
        }

        public static void SaveTextBoxData(int id, string content)
        {
            DiskIOService.SaveStringToFile($"cache/data {id}.txt", content);
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

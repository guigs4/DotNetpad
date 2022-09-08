﻿namespace Engine.Services
{
    public static class DiskIOService
    {
        public static string[] GetAllExistingCacheFiles()
        {
            string[] files = Directory.GetFiles("cache/", "data *?.txt");

            return files;
        }

        public static void CreateDefaultDirectories()
        {
            //no need to manually check if directories exist as the CreateDirectory() method already does it
            Directory.CreateDirectory("cache/");
            Directory.CreateDirectory("config/");
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }
}

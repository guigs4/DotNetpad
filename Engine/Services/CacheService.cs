﻿using IOLib;

namespace Engine.Services
{
	public static class CacheService
	{

        public static void SaveTextBoxData(string path, string content)
        {
            IO.SaveStringToFile(path, content);
        }

        public static void SaveTextBoxData(int id, string content)
        {
            IO.SaveStringToFile($"cache/data {id}.txt",content);
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
            string[] files = Directory.GetFiles("cache/", "data *?.txt");
 
            return files;
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

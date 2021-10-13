 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExpenseTracker.Model
{
    public class FileManager
    {
        string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public string ReadFileData(string fileName)
        {
            // The File path for user
            string jsonFilePath= Path.Combine(this.defaultPath, $"{fileName.ToLower()}.json");

            // Get all the File names from Directory that match *.json pattern.
            var filePaths = Directory.EnumerateFiles(defaultPath, $"*.json");

            // IF there are any files in the directory, then search for file name
            if (filePaths != null && filePaths.Any())
            {
                var userFileFound = filePaths.Where(filepath => filepath.ToLower() == jsonFilePath.ToLower()).FirstOrDefault();
                if (!string.IsNullOrEmpty(userFileFound))
                {
                    return File.ReadAllText(jsonFilePath);
                }
            }

            return null;
        }

        public bool SaveDataToFile(string fileName, string data)
        {
            // Create File name
            var jsonFileName = $"{fileName.ToLower()}.json";
            File.WriteAllText(Path.Combine(this.defaultPath, jsonFileName), data);
            return true;
        }
    }
}

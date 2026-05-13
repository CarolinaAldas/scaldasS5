using System;
using System.Collections.Generic;
using System.Text;

namespace scaldasS5.Utils
{
    public class FileAccessHelper
    {
        public static string GetFolderPath (string filePath)
        {
           
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filePath);
        }


    }
}

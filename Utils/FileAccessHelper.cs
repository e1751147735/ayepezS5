using System;
using System.Collections.Generic;
using System.Text;

namespace ayepezS5.Utils
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
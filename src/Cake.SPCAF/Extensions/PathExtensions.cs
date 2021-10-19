using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.SPCAF.Extensions
{
    public static class CakePath
    {
        public static string FullPath(Path path, ICakeEnvironment envoriment)
        {
            if (path is FilePath filePath)
            {
                return filePath.MakeAbsolute(envoriment).FullPath.Replace("/", "\\");
            }

            if (path is DirectoryPath directoryPath)
            {
                return directoryPath.MakeAbsolute(envoriment).FullPath.Replace("/", "\\"); ;
            }

            throw new ArgumentOutOfRangeException("path", "Should be FilePath or DirectoryPath");
        }

        public static string FullPathQuote(Path path, ICakeEnvironment envoriment)
        {
            return CakePath.FullPath(path, envoriment).Quote();
        }
    }
}

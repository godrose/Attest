using System;
using System.IO;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Common
{
    public static class Utils
    {
        public static string GetPathToSolutionRoot()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            while (!Directory.GetFiles(dirPath, "*.sln", SearchOption.TopDirectoryOnly).Any())
            {
                dirPath = Path.GetFullPath(dirPath + "../");
            }

            const string expectedEnding = @"/";
            if (!dirPath.EndsWith(expectedEnding))
            {
                dirPath += expectedEnding;
            }

            return dirPath;
        }
    }
}

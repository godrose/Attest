using System.IO;

namespace Attest.Testing.Core
{
    internal static class PathHelper
    {
        internal static void EnsurePath(string rootDirectory, string relativePath)
        {
            var path = Path.Combine(rootDirectory, relativePath);
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            Directory.SetCurrentDirectory(path);
        }
    }
}
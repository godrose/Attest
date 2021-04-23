using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Management
{
    internal static class ShellHelper
    {
        public static int Bash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            return process.Id;
        }

    }
}
using System;
using System.Diagnostics;

namespace Attest.Testing.Management
{
    /// <summary>
    /// Represents means for starting and stopping Windows OS processes.
    /// </summary>
    public class WindowsProcessManagementService : ProcessManagementServiceBase
    {
        /// <inheritdoc />
        public override int Start(string tool, string args)
        {
            var process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    FileName = "cmd.exe",
                    CreateNoWindow = false,
                    Arguments = $"/k {tool} {args}"
                }
            };
            process.Start();
            return process.Id;
        }

        /// <inheritdoc />
        protected override Action GetStopAction(int processId)
        {
            return () => processId.KillProcessAndChildren();
        }
    }
}

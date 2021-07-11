using System;
using System.Diagnostics;

namespace Attest.Testing.Management
{
    /// <summary>
    /// Represents means for starting and stopping MacOS processes.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class MacOSProcessManagementService : ProcessManagementServiceBase
    {
        /// <inheritdoc />
        public override int Start(string tool, string args)
        {
            return $"{tool} {args}".Bash();
        }

        /// <param name="processId"></param>
        /// <inheritdoc />
        protected override Action GetStopAction(int processId)
        {
            return () => Process.GetProcessById(processId).Kill();
        }
    }
}

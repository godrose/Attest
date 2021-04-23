using System;
using System.Diagnostics;
using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Management
{
    /// <summary>
    /// Represents means for starting and stopping MacOS processes.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class MacOSProcessManagementService : ProcessManagementServiceBase, IProcessManagementService
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

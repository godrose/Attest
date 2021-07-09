using System;

namespace Attest.Testing.Management
{
    /// <summary>
    /// Base class for starting and stopping OS processes.
    /// </summary>
    public abstract class ProcessManagementServiceBase : IProcessManagementService
    {
        /// <inheritdoc />
        public abstract int Start(string tool, string args);

        /// <inheritdoc />
        public void Stop(int processId)
        {
            var stopAction = GetStopAction(processId);
            RetryStop(stopAction);
        }

        /// <summary>
        /// Override to inject stop strategy.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        protected abstract Action GetStopAction(int processId);

        /// <summary>
        /// Override to inject your own retry stop strategy.
        /// </summary>
        /// <param name="stopAction">The stop process delegate.</param>
        protected virtual void RetryStop(Action stopAction)
        {
            stopAction.Invoke();
        }
    }
}
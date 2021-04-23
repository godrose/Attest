using System;
using Attest.Testing.Contracts;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Management
{
    /// <inheritdoc />
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
using Attest.Testing.Contracts;
using Attest.Testing.Core;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Integration
{
    /// <summary>
    /// Represents start application service for integration tests.
    /// </summary>
    /// <seealso cref="IStartApplicationService" />    
    public class StartApplicationServiceBase : IStartApplicationService
    {
        /// <inheritdoc />        
        public void Start(string startupPath)
        {
            Setup();
            OnStartCore();
            OnStart(ScenarioHelper.RootObject);
        }

        /// <summary>
        /// Override this method to perform setup functionality before the application starts.
        /// </summary>
        protected virtual void Setup()
        {            
        }

        /// <summary>
        /// Override this method to inject custom logic with regard to the application root object 
        /// immediately after the object has been created.
        /// </summary>
        /// <param name="rootObject">The root object.</param>
        protected virtual void OnStart(object rootObject)
        {            
        }

        private static void OnStartCore()
        {
            ScenarioHelper.CreateRootObject();
        }
    }
}
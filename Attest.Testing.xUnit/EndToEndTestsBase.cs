using System;
using Attest.Testing.Core;

namespace Attest.Testing.xUnit
{
    /// <summary>
    /// Base class for all End-To-End tests that use xUnit.net as test framework provider
    /// </summary>    
    public abstract class EndToEndTestsBase : Core.EndToEndTestsBase, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndToEndTestsBase"/> class.
        /// </summary>        
        protected EndToEndTestsBase()
        {
            ScenarioContext.Current = new Scenario();
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            // xUnit.net does not have dedicated attributes for Setup methods; 
            // therefore the logic is put inside the constructor instead.
            Setup();
        }

        /// <summary>
        /// Override this method to implement custom test setup logic
        /// </summary>        
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic
        /// </summary>        
        protected override void TearDown()
        {
            OnBeforeTeardown();
            TearDownCore();
            OnAfterTeardown();
        }

        private void SetupCore()
        {

        }

        /// <summary>
        /// Provides additional opportunity to modify the test setup logic
        /// </summary>
        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            ScenarioHelper.Clear();
        }

        /// <summary>
        /// Called when the teardown starts
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {

        }

        /// <summary>
        /// Called when the teardown finishes
        /// </summary>
        protected virtual void OnAfterTeardown()
        {

        }

        void IDisposable.Dispose()
        {
            TearDown();
        }
    }
}
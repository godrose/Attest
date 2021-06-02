using Attest.Testing.Context;
using NUnit.Framework;

namespace Attest.Testing.NUnit
{
    /// <summary>
    /// Base class for all End-To-End tests that use NUnit as test framework provider.
    /// </summary>    
    public abstract class EndToEndTestsBase : EndToEnd.EndToEndTestsBase        
    {
        private readonly IKeyValueDataStore _keyValueDataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndToEndTestsBase"/> class.
        /// </summary>        
        protected EndToEndTestsBase(IKeyValueDataStore keyValueDataStore)
        {
            _keyValueDataStore = keyValueDataStore;
        }

        /// <summary>
        /// Override this method to implement custom test setup logic.
        /// </summary>
        [SetUp]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        /// <summary>
        /// Override this method to implement custom test teardown logic.
        /// </summary>
        [TearDown]
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
        /// Provides additional opportunity to modify the test setup logic.
        /// </summary>
        protected virtual void SetupOverride()
        {

        }

        private void TearDownCore()
        {
            
        }

        /// <summary>
        /// Override to inject custom logic before the teardown starts.
        /// </summary>
        protected virtual void OnBeforeTeardown()
        {

        }

        /// <summary>
        /// Override to inject custom logic after the teardown finishes.
        /// </summary>
        protected virtual void OnAfterTeardown()
        {

        }
    }
}

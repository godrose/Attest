using System;
#if REQNROLL
using Reqnroll.BoDi;
#else
using BoDi;
#endif
#if REQNROLL
using Solid.IoC.Adapters.Reqnroll;
#else
using Solid.IoC.Adapters.BoDi;
#endif
#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

#if REQNROLL
namespace Attest.Testing.Reqnroll
#else
namespace Attest.Testing.SpecFlow
#endif
{
    /// <summary>
    /// Factory which is used to create instances of <see cref="CommonScenarioDataStore{TRootObject}" />
    /// </summary>    
    public static class CommonScenarioDataStoreFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="CommonScenarioDataStore{TRootObject}" />
        /// </summary>
        public static CommonScenarioDataStore<TRootObject> 
            CreateCommonScenarioDataStore<TRootObject>(
            ScenarioContext scenarioContext,
            ObjectContainer objectContainer,
            Func<TRootObject> rootObjectFactory)
        {
            var containerAdapter = new ObjectContainerAdapter(objectContainer);
            var commonScenarioDataStore =
                new CommonScenarioDataStore<TRootObject>(scenarioContext)
                {
                    RootObject = rootObjectFactory(),
                    IocContainer = containerAdapter
                };
            return commonScenarioDataStore;
        }
    }
}

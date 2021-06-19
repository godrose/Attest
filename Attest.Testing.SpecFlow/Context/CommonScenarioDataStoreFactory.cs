using System;
using BoDi;
using Solid.IoC.Adapters.BoDi;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
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

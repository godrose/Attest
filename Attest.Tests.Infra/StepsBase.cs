using System;
using Attest.Testing.SpecFlow;
using BoDi;
using TechTalk.SpecFlow;

namespace Attest.Tests.Infra
{
    public abstract class StepsBase<TRootObject>
    {
        protected CommonScenarioDataStore<TRootObject> CommonScenarioDataStore { get; }

        protected StepsBase(
            ScenarioContext scenarioContext,
            ObjectContainer objectContainer,
            Func<TRootObject> rootObjectFactory)
        {
            CommonScenarioDataStore =
                CommonScenarioDataStoreFactory.CreateCommonScenarioDataStore(
                    scenarioContext,
                    objectContainer,
                    rootObjectFactory);
        }
    }
}

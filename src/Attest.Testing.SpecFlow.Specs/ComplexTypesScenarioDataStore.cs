using System;
using System.Collections.Generic;
#if REQNROLL
using Attest.Testing.Context.Reqnroll;
#else
using Attest.Testing.Context.SpecFlow;
#endif
#if REQNROLL
using Reqnroll;
#else
using TechTalk.SpecFlow;
#endif

#if REQNROLL
namespace Attest.Testing.Reqnroll.Specs
#else
namespace Attest.Testing.SpecFlow.Specs
#endif
{
    internal sealed class ComplexTypesScenarioDataStore : ScenarioDataStoreBase
    {
        public ComplexTypesScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        public Dictionary<string, string> ComplexType
        {
            get => GetValue(new Dictionary<string, string>());
            set => SetValue(value);
        }

        public Exception Error
        {
            get => GetValue<Exception>();
            set => SetValue(value);
        }
    }
}

using System;
using System.Collections.Generic;
using Attest.Testing.Context.SpecFlow;
using TechTalk.SpecFlow;

namespace Attest.Testing.SpecFlow.Specs
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

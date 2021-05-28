using Attest.Testing.Core;
using Solid.Practices.IoC;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    public class RootObjectScenarioDataStore : ScenarioDataStoreBase
    {
        public RootObjectScenarioDataStore(ScenarioContext scenarioContext) 
            : base(scenarioContext)
        {
        }

        internal IIocContainer Container
        {
            get => GetValueImpl<IIocContainer>();
            set => SetValueImpl(value);
        }

        internal IRootObjectFactory RootObjectFactory
        {
            get => GetValueImpl<IRootObjectFactory>();
            set => SetValueImpl(value);
        }

        internal object RootObject
        {
            get => GetValueImpl<object>();
            set => SetValueImpl(value);
        }
    }
}

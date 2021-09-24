using Solid.Practices.IoC;
using TechTalk.SpecFlow;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Context.SpecFlow
{
    /// <summary>
    /// Data store for common scenarios with root object and inversion-of-control container.
    /// </summary>    
    public class CommonScenarioDataStore<TRootObject> : ScenarioDataStoreBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonScenarioDataStore{TRootObject}"/> class.
        /// </summary>
        public CommonScenarioDataStore(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        /// <summary>
        /// Gets or sets the value of the root object.
        /// </summary>
        public TRootObject RootObject
        {
            get => GetValue<TRootObject>();
            set => SetValue(value);
        }

        /// <summary>
        /// Gets or sets the value of the IoC container.
        /// </summary>
        public IIocContainer IocContainer
        {
            get => GetValue<IIocContainer>();
            set => SetValue(value);
        }
    }
}

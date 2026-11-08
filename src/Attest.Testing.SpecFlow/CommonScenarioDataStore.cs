#if REQNROLL
using Attest.Testing.Context.Reqnroll;
#else
using Attest.Testing.Context.SpecFlow;
#endif
using Solid.Practices.IoC;
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

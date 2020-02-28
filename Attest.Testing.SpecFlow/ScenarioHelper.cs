using System;
using Attest.Testing.Core;
using Solid.Practices.IoC;
using ScenarioContext = TechTalk.SpecFlow.ScenarioContext;

namespace Attest.Testing.SpecFlow
{
    /// <summary>
    /// Wrapper class over the scenario context which provides concise API of adding and retrieving services
    /// </summary>
    public class ScenarioHelper
    {
        private readonly ScenarioContext _scenarioContext;
        private const string RootObjectFactoryKey = "rootObjectFactory";
        private const string RootObjectKey = "rootObject";
        private const string ContainerKey = "container";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioHelper"/> class.
        /// </summary>
        /// <param name="scenarioContext"></param>
        public ScenarioHelper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        internal void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            _scenarioContext.Add(ContainerKey, iocContainer);
            _scenarioContext.Add(RootObjectFactoryKey, rootObjectFactory);
        }

        internal void Initialize(
            IIocContainer iocContainer)
        {
            _scenarioContext.Add(ContainerKey, iocContainer);            
        }

        /// <summary>
        /// Creates the root object and adds it to the scenario context
        /// </summary>
        public void CreateRootObject()
        {
            var rootObjectFactory = (IRootObjectFactory)_scenarioContext[RootObjectFactoryKey];
            _scenarioContext.Add(RootObjectKey, rootObjectFactory.CreateRootObject());
        }

        /// <summary>
        /// Adds an item to the scenario context
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="item">Item</param>
        public void Add<TItem>(TItem item) where TItem : class
        {           
            var typeName = GetKey<TItem>();
            AddImpl(item, typeName);
        }

        /// <summary>
        /// Adds an item to the scenario context as the specific type
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="item">Item</param>
        /// <param name="addAsType">Specific type which will be used to retrieve the item</param>
        public void Add<TItem>(TItem item, Type addAsType) where TItem : class
        {
            var typeName = addAsType.Name;
            AddImpl(item, typeName);
        }

        private void AddImpl<TItem>(TItem item, string typeName) where TItem : class
        {
            if (_scenarioContext.ContainsKey(typeName))
            {
                _scenarioContext[typeName] = item;
            }
            else
            {
                _scenarioContext.Add(typeName, item);
            }
        }

        /// <summary>
        /// Gets the item from the scenario context by type if found, otherwise null
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <returns>Retrieved item</returns>
        public TItem Get<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            if (_scenarioContext.ContainsKey(typeName))
            {
                return _scenarioContext[typeName] as TItem;
            }
            return null;
        }

        /// <summary>
        /// Determines whether the item is stored inside the scenario context by type
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <returns>True, if the item is found, otherwise false</returns>
        public bool Contains<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            return _scenarioContext.ContainsKey(typeName);
        }

        /// <summary>
        /// Gets the stored item from the scenario context by type if found, otherwise creates
        /// a new instance by simple instantiation, stores it in the scenario context and returns it eventually
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <returns>Item</returns>
        public TItem GetOrCreate<TItem>() where TItem : class, new()
        {
            return GetOrCreateImpl(() => new TItem());
        }

        /// <summary>
        /// Gets the stored item from the scenario context by type if found, otherwise creates
        /// a new instance by invoking the provided creator function, stores it in the scenario context and returns it eventually
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="creatorFunc">Item creation function</param>
        /// <returns>Item</returns>
        public TItem GetOrCreate<TItem>(Func<TItem> creatorFunc) where TItem : class
        {
            return GetOrCreateImpl(creatorFunc);
        }

        private TItem GetOrCreateImpl<TItem>(Func<TItem> creatorFunc) where TItem : class
        {
            TItem item;
            if (Contains<TItem>() == false)
            {
                item = creatorFunc();
                Add(item);
            }
            else
            {
                item = Get<TItem>();
            }
            return item;
        }

        private string GetKey<TItem>() where TItem : class
        {
            var type = typeof (TItem);
            var typeName = type.Name;
            return typeName;
        }

        /// <summary>
        /// Clears the data.
        /// </summary>
        public void Clear()
        {
            _scenarioContext.Clear();
        }

        internal object Container => _scenarioContext[ContainerKey];

        /// <summary>
        /// Dependency registrator.
        /// </summary>
        internal IDependencyRegistrator Registrator => _scenarioContext[ContainerKey] as IDependencyRegistrator;

        /// <summary>
        /// Root object.
        /// </summary>
        public object RootObject => _scenarioContext[RootObjectKey];
    }
}
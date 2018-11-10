using System;
using Solid.Practices.IoC;

namespace Attest.Testing.Core
{
    /// <summary>
    /// Wrapper class over the scenario context which provides concise API of adding and retrieving services
    /// as well as scenario initialization logic with respect to the root object and ioc container adapter.
    /// </summary>
    public static class ScenarioHelper
    {
        private const string RootObjectFactoryKey = "rootObjectFactory";
        private const string RootObjectKey = "rootObject";        
        private const string RegistratorKey = "registrator";
        private const string ResolverKey = "resolver";

        /// <summary>
        /// Initializes the <see cref="ScenarioContext"/>. with the provided container and root object factory.
        /// </summary>
        /// <param name="iocContainer">The ioc container.</param>
        /// <param name="rootObjectFactory">The root object factory.</param>
        public static void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {            
            ScenarioContext.Current.Add(RegistratorKey, iocContainer);
            ScenarioContext.Current.Add(ResolverKey, iocContainer);
            ScenarioContext.Current.Add(RootObjectFactoryKey, rootObjectFactory);                        
        }

        /// <summary>
        /// Creates the root object and adds it to the scenario context.
        /// </summary>
        public static void CreateRootObject()
        {
            var rootObjectFactory = (IRootObjectFactory)ScenarioContext.Current[RootObjectFactoryKey];
            ScenarioContext.Current.Add(RootObjectKey, rootObjectFactory.CreateRootObject());
        }

        /// <summary>
        /// Adds an item to the scenario context.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <param name="item">Item.</param>
        public static void Add<TItem>(TItem item) where TItem : class
        {
            var typeName = GetKey<TItem>();
            AddImpl(item, typeName);
        }

        /// <summary>
        /// Adds an item to the scenario context as the specific type.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <param name="item">Item.</param>
        /// <param name="addAsType">Specific type which will be used to retrieve the item.</param>
        public static void Add<TItem>(TItem item, Type addAsType) where TItem : class
        {
            var typeName = addAsType.Name;
            AddImpl(item, typeName);
        }

        private static void AddImpl<TItem>(TItem item, string typeName) where TItem : class
        {
            if (ScenarioContext.Current.ContainsKey(typeName))
            {
                ScenarioContext.Current[typeName] = item;
            }
            else
            {
                ScenarioContext.Current.Add(typeName, item);
            }
        }

        /// <summary>
        /// Gets the item from the scenario context by type if found, otherwise null.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <returns>Retrieved item.</returns>
        public static TItem Get<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            if (ScenarioContext.Current.ContainsKey(typeName))
            {
                return ScenarioContext.Current[typeName] as TItem;
            }
            return null;
        }

        /// <summary>
        /// Determines whether the item is stored inside the scenario context by type.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <returns>True, if the item is found, otherwise false.</returns>
        public static bool Contains<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            return ScenarioContext.Current.ContainsKey(typeName);
        }

        /// <summary>
        /// Gets the stored item from the scenario context by type if found, otherwise creates
        /// a new instance by simple instantiation, stores it in the scenario context and returns it eventually.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <returns>Item.</returns>
        public static TItem GetOrCreate<TItem>() where TItem : class, new()
        {
            return GetOrCreateImpl(() => new TItem());
        }

        /// <summary>
        /// Gets the stored item from the scenario context by type if found, otherwise creates
        /// a new instance by invoking the provided creator function, stores it in the scenario context and returns it eventually.
        /// </summary>
        /// <typeparam name="TItem">Type of item.</typeparam>
        /// <param name="creatorFunc">Item creation function.</param>
        /// <returns>Item</returns>
        public static TItem GetOrCreate<TItem>(Func<TItem> creatorFunc) where TItem : class
        {
            return GetOrCreateImpl(creatorFunc);
        }

        private static TItem GetOrCreateImpl<TItem>(Func<TItem> creatorFunc) where TItem : class
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

        private static string GetKey<TItem>() where TItem : class
        {
            var type = typeof(TItem);
            var typeName = type.Name;
            return typeName;
        }

        /// <summary>
        /// Clears the <see cref="ScenarioContext"/>.
        /// </summary>
        public static void Clear()
        {
            ScenarioContext.Current.Clear();
        }        

        /// <summary>
        /// Gets the dependency registrator.
        /// </summary>
        /// <value>
        /// The ioc container adapter.
        /// </value>
        public static IDependencyRegistrator Registrator
        {
            get { return (IDependencyRegistrator)ScenarioContext.Current[RegistratorKey]; }
        }

        /// <summary>
        /// Root object instance.
        /// </summary>
        public static object RootObject
        {
            get { return ScenarioContext.Current[RootObjectKey]; }
        }
    }
}

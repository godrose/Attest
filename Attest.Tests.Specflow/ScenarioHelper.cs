using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Attest.Tests.Specflow
{
    public static class ScenarioHelper
    {
        private const string RootObjectFactoryKey = "rootObjectFactory";
        private const string RootObjectKey = "rootObject";
        private const string ContainerKey = "container";

        internal static void Initialize(
            IIocContainer iocContainer,
            IRootObjectFactory rootObjectFactory)
        {
            ScenarioContext.Current.Add(ContainerKey, iocContainer);
            ScenarioContext.Current.Add(RootObjectFactoryKey, rootObjectFactory);
        }

        public static void CreateRootObject()
        {
            var rootObjectFactory = (IRootObjectFactory)ScenarioContext.Current[RootObjectFactoryKey];
            ScenarioContext.Current.Add(RootObjectKey, rootObjectFactory.CreateRootObject());
        }

        public static void Add<TItem>(TItem item) where TItem : class
        {           
            var typeName = GetKey<TItem>();
            if (ScenarioContext.Current.ContainsKey(typeName))
            {
                ScenarioContext.Current[typeName] = item;
            }
            else
            {                
                ScenarioContext.Current.Add(typeName, item);
            }
        }

        public static TItem Get<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            if (ScenarioContext.Current.ContainsKey(typeName))
            {
                return ScenarioContext.Current[typeName] as TItem;
            }
            return null;
        }

        public static bool Contains<TItem>() where TItem : class
        {
            var typeName = GetKey<TItem>();
            return ScenarioContext.Current.ContainsKey(typeName);
        }

        public static TItem Resolve<TItem>() where TItem : class, new()
        {
            TItem item;
            if (Contains<TItem>() == false)
            {
                item = new TItem();
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
            var type = typeof (TItem);
            var typeName = type.Name;
            return typeName;
        }


        internal static void Clear()
        {
            ScenarioContext.Current.Clear();
        }

        internal static object Container
        {
            get { return ScenarioContext.Current[ContainerKey]; }
        }

        public static object RootObject
        {
            get { return ScenarioContext.Current[RootObjectKey]; }
        }
    }
}
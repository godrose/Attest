using System;
using System.Reflection;

namespace Attest.Fake.Conventions
{
    /// <summary>
    /// Builder factory for convention-based builder creation.
    /// </summary>
    public static class BuilderFactory
    {
        /// <summary>
        /// Creates an instance of builder specified by its type.
        /// It uses <see cref="ConventionsStore.CreateBuilderMethodName"/> to resolve the factory method name.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateBuilderInstance(Type type) => CreateBuilderInstanceImpl(type);

        private static object CreateBuilderInstanceImpl(Type type) =>
            type.GetRuntimeMethod(ConventionsStore.CreateBuilderMethodName(), new Type[] { }).Invoke(null, null);
    }
}

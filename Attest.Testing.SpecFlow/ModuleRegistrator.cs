using System.Collections.Generic;
using System.Linq;
using Attest.Tests.Core;

namespace Attest.Tests.SpecFlow
{
    /// <summary>
    /// This class provides option to register 
    /// collection of steps modules into the current 
    /// scenario context
    /// </summary>
    public static class ModuleRegistrator
    {
        /// <summary>
        /// registers the collection of steps modules 
        /// into the current scenario context
        /// </summary>
        /// <param name="modules">
        /// collection of steps modules
        /// </param>
        public static void RegisterModules(IEnumerable<IStepsModule> modules)
        {
            foreach (var stepsModule in modules)
            {
                RegisterStepsProviders(stepsModule);
            }
        }        

        private static void RegisterStepsProviders(IStepsModule stepsModule)
        {
            var stepsProviders = stepsModule.GetStepsProviders().ToArray();
            foreach (var stepsProvider in stepsProviders)
            {
                RegisterStepsProvider(stepsProvider);
            }
        }

        private static void RegisterStepsProvider(IStepsProvider stepsProvider)
        {
            var concreteType = stepsProvider.GetType();
            var declaredInterfaces = concreteType.GetInterfaces().ToArray();
            //using the I[Area]StepsProvider -> [Area]StepsProvider naming convention
            var candidateType = declaredInterfaces.FirstOrDefault(t => t.Name.Equals("I" + concreteType.Name));

            if (candidateType != null)
            {
                ScenarioHelper.Add(stepsProvider, candidateType);
            }
        }
    }
}

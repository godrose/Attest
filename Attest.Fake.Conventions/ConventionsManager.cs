using System;

namespace Attest.Fake.Conventions
{
    /// <summary>
    /// Conventions manager for provider-contract-builder-fake relationship
    /// </summary>
    public static class ConventionsManager
    {
        /// <summary>
        /// Gets the default ending for assembly which holds providers' contracts.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> ContractsAssemblyEnding => () => "Contracts.Providers";
        /// <summary>
        /// Gets the default ending for assembly which holds providers' fake implementations.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> FakeAssemblyEnding => () => "Fake.Providers";
        /// <summary>
        /// Gets the default ending for assembly which holds providers' builders.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> BuildersAssemblyEnding => () => "Fake.ProviderBuilders";
        /// <summary>
        /// Gets the default ending for assembly which holds providers' simulators.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> SimulatorsAssemblyEnding => () => "Fake.Simulators";
        /// <summary>
        /// Gets the default ending for type which represents provider's builder.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> BuilderEnding => () => "Builder";
        /// <summary>
        /// Gets the default ending for type which represents provider's contract/fake implementation.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> ProviderEnding => () => "Provider";
        /// <summary>
        /// Gets the default ending for type which represents provider's simulator.
        /// Override to provide custom ending.
        /// </summary>
        public static Func<string> SimulatorEnding => () => "Simulator";
        /// <summary>
        /// Gets the default prefix for type which represents provider's fake implementation.
        /// Override to provide custom prefix.
        /// </summary>
        public static Func<string> FakePrefix => () => "Fake";
        /// <summary>
        /// Gets the default method name for builder factory method.
        /// Override to provide custom name.
        /// </summary>
        public static Func<string> CreateBuilderMethodName => () => "CreateBuilder";
    }
}
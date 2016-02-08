using System;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents method description, storing the callback type.
    /// </summary>
    public interface IMethodCallMetaData
    {
        /// <summary>
        /// Gets the run method description.
        /// </summary>
        /// <value>
        /// The run method description.
        /// </value>
        string RunMethodDescription { get; }

        /// <summary>
        /// Gets the type of the callback.
        /// </summary>
        /// <value>
        /// The type of the callback.
        /// </value>
        Type CallbackType { get; }
    }
}
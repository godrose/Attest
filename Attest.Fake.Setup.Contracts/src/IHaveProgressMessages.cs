using System.Collections.Generic;

namespace Attest.Fake.Setup.Contracts
{
    /// <summary>
    /// Represents an object that contains progress messages.
    /// </summary>
    public interface IHaveProgressMessages
    {
        /// <summary>
        /// Gets the progress messages.
        /// </summary>
        /// <value>
        /// The progress messages.
        /// </value>
        IEnumerable<object> ProgressMessages { get; }
    }
}
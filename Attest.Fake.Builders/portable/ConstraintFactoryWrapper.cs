using Attest.Fake.Core;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Wraps around current value of <see cref="ConstraintFactoryContext.Current"/>
    /// </summary>
    public class ConstraintFactoryWrapper
    {
        /// <summary>
        /// Represents a shortcut for the <see cref="ConstraintFactoryContext.Current"/>
        /// </summary>
        protected static readonly IConstraintFactory It = ConstraintFactoryContext.Current;
    }
}
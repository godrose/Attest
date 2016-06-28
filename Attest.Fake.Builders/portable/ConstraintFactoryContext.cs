using Attest.Fake.Core;

namespace Attest.Fake.Builders
{
    /// <summary>
    /// Ambient context for <see cref="IConstraintFactory"/>
    /// </summary>
    public class ConstraintFactoryContext
    {
        private static IConstraintFactory _constraintFactory;

        /// <summary>
        /// Gets or sets the current value of <see cref="IConstraintFactory"/>.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IConstraintFactory Current
        {
            get { return _constraintFactory; }
            set { _constraintFactory = value; }
        }
    }
}

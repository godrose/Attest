using System;
using System.Linq.Expressions;
using Attest.Fake.Core;
using Moq;

namespace Attest.Fake.Moq
{
    public class ConstraintFactory : IConstraintFactory
    {
        public TValue IsAny<TValue>()
        {
            return It.IsAny<TValue>();
        }

        public TValue Matches<TValue>(Expression<Func<TValue, bool>> predicate)
        {
            return It.Is(predicate);
        }
    }
}

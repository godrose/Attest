using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup
{
    class ServiceSetupFactory<TService> : IServiceSetupFactory<TService> where TService : class
    {
        public IFake<TService> SetupFakeService(IFake<TService> fake, IEnumerable<IMethodCallMetaData> methodCalls)
        {            
            var calls = methodCalls as IMethodCallMetaData[] ?? methodCalls.ToArray();
            VisitMethodCalls(new MethodCallVisitor<TService>(fake) as IMethodCallVisitor<TService>, calls);
            VisitMethodCalls(new MethodCallWithResultVisitor<TService>(fake) as IMethodCallWithResultVisitor<TService>, calls);
            return fake;
        }

        private static void VisitMethodCalls<TVisitor>(TVisitor visitor, IEnumerable<object> methodCalls)
        {
            foreach (var methodCall in methodCalls.OfType<IAcceptor<TVisitor>>())
            {
                methodCall.Accept(visitor);
            }
        }
    }
}

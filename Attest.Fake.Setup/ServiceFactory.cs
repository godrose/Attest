using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public class ServiceFactory<TService> : IServiceFactory<TService> where TService : class
    {
        public TService CreateService(IFake<TService> fake, IEnumerable<object> methodCalls)
        {            
            var calls = methodCalls as object[] ?? methodCalls.ToArray();
            VisitMethodCalls(new MethodCallVisitor<TService>(fake) as IMethodCallVisitor<TService>, calls);
            VisitMethodCalls(new MethodCallWithResultVisitor<TService>(fake) as IMethodCallWithResultVisitor<TService>, calls);
            return fake.Object;
        }

        private void VisitMethodCalls<TVisitor>(TVisitor visitor, IEnumerable<object> methodCalls)
        {
            foreach (var methodCall in methodCalls.OfType<IAcceptorWithParameters<TVisitor>>())
            {
                methodCall.Accept(visitor);
            }
        }
    }
}

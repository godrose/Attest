using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup
{
    class ServiceSetupFactory<TService> : IServiceSetupFactory<TService> where TService : class
    {
        IFake<TService> IServiceSetupFactory<TService>.SetupFakeService(
            IFake<TService> fake, 
            IEnumerable<IMethodCallMetaData> methodCalls)
        {            
            var calls = methodCalls as IMethodCallMetaData[] ?? methodCalls.ToArray();
            VisitMethodCalls(new MethodCallVisitor<TService>(fake) as IMethodCallVisitor<TService>, calls);
            VisitMethodCalls(new MethodCallWithResultVisitor<TService>(fake) as IMethodCallWithResultVisitor<TService>, calls);
            return fake;
        }

        IFake<TService> IServiceSetupFactory<TService>.SetupFakeService(
            IFake<TService> fake, 
            IEnumerable<IMethodCall<TService>> methodCalls, 
            IEnumerable<IMethodCallWithResult<TService>> methodCallsWithResult)
        {
            var methodCallVisitor = new MethodCallVisitor<TService>(fake) as IMethodCallVisitor<TService>;
            var methodCallWithResultVisitor = new MethodCallWithResultVisitor<TService>(fake);
            AcceptMany(methodCalls, methodCallVisitor);            
            AcceptMany(methodCallsWithResult, methodCallWithResultVisitor);
            return fake;
        }        

        private static void VisitMethodCalls<TVisitor>(TVisitor visitor, IEnumerable<object> methodCalls)
        {
            AcceptMany(methodCalls.OfType<IAcceptor<TVisitor>>(),visitor);            
        }

        private static void AcceptMany<TAcceptor, TVisitor>(IEnumerable<TAcceptor> methodCalls, TVisitor methodCallVisitor)
            where TAcceptor : IAcceptor<TVisitor>
        {
            foreach (var methodCall in methodCalls)
            {
                methodCall.Accept(methodCallVisitor);
            }
        }
    }
}

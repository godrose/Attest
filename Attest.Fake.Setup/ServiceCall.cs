using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Solid.Patterns.Visitor;

namespace Attest.Fake.Setup
{      
    public class ServiceCall<TService> : IServiceCall<TService>, IHaveNoMethods<TService> where TService : class
    {
        private readonly IFake<TService> _fake;
        private readonly IServiceSetupFactory<TService> _serviceSetupFactory = new ServiceSetupFactory<TService>();

        private ServiceCall(IFake<TService> fake)
        {
            _fake = fake;
        }

        private readonly List<IMethodCallMetaData> _methodCalls = new List<IMethodCallMetaData>();

        private IEnumerable<IMethodCallMetaData> MethodCalls
        {
            get { return _methodCalls; }
        }
        IEnumerable<IMethodCallMetaData> IHaveMethods<TService>.MethodCalls 
        {
            get { return MethodCalls; }
        }

        public static IHaveNoMethods<TService> CreateServiceCall(IFake<TService> fake)
        {
            return new ServiceCall<TService>(fake);
        }

        private void AddMethodCall(IMethodCallMetaData methodCallMetaData)
        {
            var newMethodInfo = methodCallMetaData as IAcceptor<IMethodCallVisitor<TService>>;
            if (newMethodInfo != null)
            {
                AddMethodCallImpl(methodCallMetaData, newMethodInfo);
            }
            else
            {
                var newMethodWithResultInfo = methodCallMetaData as IAcceptor<IMethodCallWithResultVisitor<TService>>;
                if (newMethodWithResultInfo == null)
                {
                    throw new ArgumentException(
                        "Only method calls that implement acceptor for either MethodInfo or MethodInfoWithResult visitors are allowed",
                        "methodCallMetaData");
                }
                AddMethodCallWithResultImpl(methodCallMetaData, newMethodWithResultInfo);
            }
        }        

        public IServiceCall<TService> AddMethodCall<TCallback>(IMethodCall<TService,TCallback> methodCall)
        {
            AddMethodCallImpl(methodCall, methodCall);   
            return this;
        }

        public IServiceCall<TService> AddMethodCall<TCallback, TResult>(IMethodCallWithResult<TService, TCallback, TResult> methodCall)
        {
            AddMethodCallWithResultImpl(methodCall, methodCall);
            return this;
        }

        private void AddMethodCallImpl(IMethodCallMetaData methodCallMetaData, IAcceptor<IMethodCallVisitor<TService>> acceptor)
        {
            var existingMethodCallMetaData = FindExistingMethodCallMetaData(methodCallMetaData);
            if (existingMethodCallMetaData == null)
            {
                _methodCalls.Add(methodCallMetaData);
            }
            else
            {
                AssertCallbackType(methodCallMetaData, existingMethodCallMetaData);                
                AcceptExistingMethodCall(
                    acceptor,
                    new MethodCallAppendCallsVisitor<TService>(methodCallMetaData));
            }
        }

        private void AddMethodCallWithResultImpl(IMethodCallMetaData methodCallMetaData, 
            IAcceptor<IMethodCallWithResultVisitor<TService>> acceptor)
        {
            var existingMethodCallMetaData = FindExistingMethodCallMetaData(methodCallMetaData);
            if (existingMethodCallMetaData == null)
            {
                _methodCalls.Add(methodCallMetaData);
            }
            else
            {
                AssertCallbackType(methodCallMetaData, existingMethodCallMetaData);                
                AcceptExistingMethodCall(
                        acceptor,
                        new MethodCallWithResultAppendCallsVisitor<TService>(methodCallMetaData));
            }
        }

        private static void AcceptExistingMethodCall<TAppendCallsVisitor,TMethodCallVisitor>(
            IAcceptor<TMethodCallVisitor> existingMethodInfoMetaData,
            TAppendCallsVisitor appendCallsVisitor
            ) where TAppendCallsVisitor : TMethodCallVisitor
        {
            existingMethodInfoMetaData.Accept(appendCallsVisitor);
        }

        private static void AssertCallbackType(IMethodCallMetaData newMethodCallMetaData,
            IMethodCallMetaData existingMethodCallMetaData)
        {
            var newCallbackType = newMethodCallMetaData.CallbackType;
            var existingCallbackType = existingMethodCallMetaData.CallbackType;
            if (newCallbackType != existingCallbackType)
            {
                throw new NotSupportedException("Callback type may not be changed");
            }
        }

        private IMethodCallMetaData FindExistingMethodCallMetaData(IMethodCallMetaData methodCallMetaData)
        {
            var newRunMethodDescription = methodCallMetaData.RunMethodDescription;
            var existingMethodInfoMetaData =
                _methodCalls.FirstOrDefault(t => t.RunMethodDescription == newRunMethodDescription);
            return existingMethodInfoMetaData;
        }

        public IFake<TService> SetupService()
        {
            return _serviceSetupFactory.SetupFakeService(_fake, MethodCalls);          
        }

        public void AppendMethods(IHaveMethods<TService> otherMethods)
        {
            foreach (var otherMethod in otherMethods.MethodCalls)
            {
                AddMethodCall(otherMethod);
            }
        }
    }
}
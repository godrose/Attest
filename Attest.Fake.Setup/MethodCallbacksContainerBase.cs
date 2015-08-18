using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    public abstract class HaveCallbacksBase<TCallback> : IHaveCallbacks<TCallback>
    {
        protected readonly List<TCallback> Callbacks = new List<TCallback>();
        IEnumerable<TCallback> IHaveCallbacks<TCallback>.Callbacks
        {
            get { return Callbacks; }
        }
    }

    public abstract class MethodCallbacksContainerBase<TCallback> : 
        HaveCallbacksBase<TCallback>, 
        IMethodCallbacksContainer<TCallback>                
    {
        private int _index;

        protected MethodCallbacksContainerBase()
        {
            CallbackType = typeof (TCallback);
        }

        public abstract string RunMethodDescription { get; protected set; }
        public Type CallbackType { get; private set; }

        public TCallback YieldCallback()
        {
            //last callback is the default one
            //this will cover two cases:
            //1) defined too little callbacks - the last one is the default one
            //2) defined one callback - it's implied to be the default one
            return Callbacks.Count == 1 ? Callbacks.Single() : Callbacks[_index++];
        }

        protected void AddCallbackImpl(TCallback methodCallback)
        {
            Callbacks.Add(methodCallback);
        }

        public void AppendCallbacks(IHaveCallbacks<TCallback> haveCallbacks)
        {
            Callbacks.AddRange(haveCallbacks.Callbacks);
        }
    }
}
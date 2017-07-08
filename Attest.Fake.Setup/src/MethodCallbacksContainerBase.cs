using System;
using System.Linq;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup
{
    /// <summary>
    /// Base class for callbacks container
    /// </summary>
    /// <typeparam name="TCallback"></typeparam>
    public abstract class MethodCallbacksContainerBase<TCallback> : 
        HaveCallbacksBase<TCallback>, 
        IMethodCallbacksContainer<TCallback>                
    {
        private int _index;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodCallbacksContainerBase{TCallback}"/> class.
        /// </summary>
        protected MethodCallbacksContainerBase()
        {
            CallbackType = typeof (TCallback);
        }

        /// <summary>
        /// Gets the run method description.
        /// </summary>
        /// <value>
        /// The run method description.
        /// </value>
        public abstract string RunMethodDescription { get; protected set; }

        /// <summary>
        /// Gets the type of the callback.
        /// </summary>
        /// <value>
        /// The type of the callback.
        /// </value>
        public Type CallbackType { get; private set; }

        /// <summary>
        /// Call this method to yield the next callback from the collection of callbacks.
        /// </summary>
        /// <returns>Next callback</returns>
        public TCallback YieldCallback()
        {
            //last callback is the default one
            //this will cover two cases:
            //1) defined too little callbacks - the last one is the default one
            //2) defined one callback - it's implied to be the default one
            return Callbacks.Count == 1 ? Callbacks.Single() : Callbacks[_index++];
        }

        /// <summary>
        /// Adds the callback to the end of the collection.
        /// </summary>
        /// <param name="methodCallback">The method callback.</param>
        protected void AddCallbackInternal(TCallback methodCallback)
        {
            Callbacks.Add(methodCallback);
        }

        /// <summary>
        /// Appends the callbacks.
        /// </summary>
        /// <param name="haveCallbacks">An object that has callbacks.</param>
        public void AppendCallbacks(IHaveCallbacks<TCallback> haveCallbacks)
        {
            Callbacks.AddRange(haveCallbacks.Callbacks);
        }
    }
}
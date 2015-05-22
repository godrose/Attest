using System;
using Attest.Fake.Core;
using Attest.Tests.Core;
using NUnit.Framework;
using Solid.Practices.IoC;

namespace Attest.Tests.NUnit
{
    public abstract class IntegrationTestsBase<TContainer, TFakeFactory, TRootObject, TBootstrapper> : 
        IntegrationTestsBase<TContainer, TFakeFactory, TRootObject>     
        where TContainer : IIocContainer, new()
        where TFakeFactory : IFakeFactory, new() where TRootObject : class
    {        
        [SetUp]
        protected override void Setup()
        {
            SetupCore();
            SetupOverride();
        }

        [TearDown]
        protected override void TearDown()
        {
            TearDownCore();
            TearDownOverride();
        }

        private void SetupCore()
        {
            IocContainer = new TContainer();
            Activator.CreateInstance(typeof (TBootstrapper), IocContainer);            
        }

        protected virtual void SetupOverride()
        {
            
        }

        private void TearDownCore()
        {
            //Dispose();
        }

        protected virtual void TearDownOverride()
        {
            
        }        
    }
}

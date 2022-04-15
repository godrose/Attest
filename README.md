# Short description

In short `Attest` framework provides tools for two major aspects during app development: 

  1. inexistent/unavailable data either at the frontend or at the backend part of the app

  2. fast test creation and low maintenance costs

It does so by modeling various services and dependencies and providing out-of-the-box implementations which can be extended to match virtually any use case in the real world

# Where to start

You can clone the source code by using `git clone` and then create packages locally to use them:

### Windows:
`./devops/publish/publish-all.bat`

### Linux/Mac
Coming soon...

Or you can use the already published packages from Nuget by simply executing:
`dotnet add [package_name]` 

# Typical use cases

## Fake Data Layer
Imagine you're developing a backend service which connects to an external provider to query for some data or send commands. You'd also like to test the logic of the service by unit tests, i.e. without actually calling the provider to get some data. This is exactly where you would use so-called **Fake Data Providers** which typically run in memory as opposed to **Real Data Providers** which would call the external dependency. 

Let see the following structure (some parts are omitted for brevity):

```csharp
    [Route("api/data/[controller]")]
    public sealed class AlgorithmsController : ControllerBase
    {
        private readonly IAlgorithmProvider _algorithmProvider;

        public AlgorithmsController(IAlgorithmProvider algorithmProvider)
        {
            _algorithmProvider = algorithmProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_algorithmProvider.GetAlgorithms());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to get algorithms: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(_algorithmProvider.GetAlgorithm(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Unable to get algorithm by id {id} : {ex.Message}");
            }
        }
    }
```

```csharp
public interface IAlgorithmProvider
    {
        FullAlgorithmInfoDto[] GetAlgorithms();
        FullAlgorithmInfoDto GetAlgorithm(string algorithmId);
    }
```

So if we were to write unit tests for the controller methods that would be hard if all our implementation of the `IAlgorithmProvider` were pointing to and external storage/service.
Thankfully by using clever dependency registration and further injection we can define a **Fake** version of this functionality and then use it anywhere to test the controller under various conditions.

To use the examples below add the following packages
```
dotnet add Attest.Fake.Builders
dotnet add Attest.Fake.Moq
```

First we define provider builder which will contain the data used during the test execution and respond to method calls. Our fake provider will actually delegate work to it during text execution. This provider builder can also support edge cases like throwing an exception to ensure the calling class can cope with them.

```csharp
public class AlgorithmProviderBuilder : FakeBuilderBase<IAlgorithmProvider>.WithInitialSetup
    {
        private readonly List<FullAlgorithmInfoDto> _algorithms = new List<FullAlgorithmInfoDto>();
        private string _error;

        private AlgorithmProviderBuilder()
        {
        }

        public static AlgorithmProviderBuilder CreateBuilder()
        {
            return new AlgorithmProviderBuilder();
        }

        protected override IServiceCall<IAlgorithmProvider>
            CreateServiceCall(IHaveNoMethods<IAlgorithmProvider> serviceCallTemplate)
        {
            return serviceCallTemplate
                .AddMethodCallWithResult(
                    t => t.GetAlgorithms(),
                    r => _error == null ? r.Complete(_algorithms.ToArray()) : r.Throw(new Exception(_error)))
                .AddMethodCallWithResult<string, FullAlgorithmInfoDto>(
                    t => t.GetAlgorithm(It.IsAny<string>()),
                    (r, id) => r.Complete(FindAlgorithm));
        }

        public AlgorithmProviderBuilder WithAlgorithms(IEnumerable<FullAlgorithmInfoDto> algorithms)
        {
            _algorithms.Clear();
            _algorithms.AddRange(algorithms);
            return this;
        }

        public AlgorithmProviderBuilder WithError(string error)
        {
            _error = error;
            return this;
        }

        public AlgorithmProviderBuilder WithParameters(string algorithmId,
            IEnumerable<ParameterDefinitionDto> parameters)
        {
            var algorithm = _algorithms.FirstOrDefault(t => t.Id == algorithmId);
            algorithm?.Parameters.AddRange(parameters);
            return this;
        }

        private FullAlgorithmInfoDto FindAlgorithm(string algorithmId)
        {
            return _algorithms.FirstOrDefault(k => k.Id == algorithmId);
        }
    }
```
The initial data is injected via container during provider creation and can be read from an external data setup file or put manually

```csharp
public interface IAlgorithmContainer
    {
        IEnumerable<FullAlgorithmInfoDto> Algorithms { get; }
    }
    
    public class AlgorithmContainer : IAlgorithmContainer
    {
        private readonly List<FullAlgorithmInfoDto> _algorithms = new List<FullAlgorithmInfoDto>();
        public IEnumerable<FullAlgorithmInfoDto> Algorithms => _algorithms;

        public void UpdateAlgorithms(IEnumerable<FullAlgorithmInfoDto> algorithms)
        {
            _algorithms.Clear();
            _algorithms.AddRange(algorithms);
        }
    }  
```

And finally the fake provider will implement the provider contract and delegate all calls to the provider builder.

```csharp
internal sealed class FakeAlgorithmProvider : FakeProviderBase<AlgorithmProviderBuilder, IAlgorithmProvider>,
        IAlgorithmProvider
    {
        public FakeAlgorithmProvider(
            AlgorithmProviderBuilder algorithmProviderBuilder,
            IAlgorithmContainer algorithmContainer)
            :base(algorithmProviderBuilder)
        {
            algorithmProviderBuilder.WithAlgorithms(algorithmContainer.Algorithms);
        }

        FullAlgorithmInfoDto[] IAlgorithmProvider.GetAlgorithms() =>
            GetService().GetAlgorithms();

        FullAlgorithmInfoDto IAlgorithmProvider.GetAlgorithm(string id) =>
            GetService().GetAlgorithm(id);
    }
```

To sum it up, having such setup will allow testing any data-bound piece of your app, running the whole app on fake data layer thus resolving any real data bottleneck and much more.

## Enhanced SpecFlow experience
If you're familiar with the BDD/ATDD tool for .NET called `SpecFlow` you know that it allows to do many exciting things while writing specs/tests. If not then please go ahead and read - you wouldn't regret it. The `Attest` framework builds on top of this tool and provides clean flow for scenario/test lifecycle including setup/teardown, dependencies registration, etc. This allows you to focus on writing steps implementation.

To use the examples below add the following packages
```
dotnet add Attest.Tests.Core
```

Then add the following classes:

```csharp
    [Binding]
    internal sealed class LifecycleHook : LifecycleHookBase
    {
        public LifecycleHook(ObjectContainer objectContainer) 
            : base(objectContainer)
        {

        }

        protected override void InitializeContainer(IIocContainer iocContainer)
        {
            new Startup(iocContainer).Initialize();
        }

        [AfterTestRun]
        public new static void AfterAllScenarios()
        {
            LifecycleHookBase.AfterAllScenarios();
        }
    }
```
This class enables the lifecycle functionality to be hooked into the process when the scenario is executed


```csharp
internal sealed class Startup : StartupBase<Bootstrapper>
    {
        public Startup(IIocContainer iocContainer)
            :base(iocContainer, c => new Bootstrapper(c))
        {
        }

        protected override void InitializeOverride(Bootstrapper bootstrapper)
        {
            base.InitializeOverride(bootstrapper);

            AssemblyLoader.LoadAssembliesFromPaths = RuntimeAssemblyLoader.Get;
            bootstrapper.UseScenarioDataStores();
        }
    }
```
This class provides options to inject any dependencies that need to be registered before the scenario starts

# Build Status

<img src=https://ci.appveyor.com/api/projects/status/github/godrose/Attest>


# Artifacts status

| Name | # of Downloads | Living Doc | Download link |
| ---- | -------------- | ---------- | ------------- |
| Core | <img src=https://img.shields.io/nuget/dt/Attest.Tests.Core> | [Living Documentation](https://ci.appveyor.com/api/projects/godrose/Attest/artifacts/output/Attest.Testing.Core.Specs.LivingDoc.html) | [Get package](https://www.nuget.org/packages/Attest.Tests.Core/) |
| SpecFlow | <img src=https://img.shields.io/nuget/dt/Attest.Tests.SpecFlow> | [Living Documentation](https://ci.appveyor.com/api/projects/godrose/Attest/artifacts/output/Attest.Testing.SpecFlow.Specs.LivingDoc.html) | [Get package](https://www.nuget.org/packages/Attest.Tests.SpecFlow/) |
| Setup | <img src=https://img.shields.io/nuget/dt/Attest.Fake.Setup> | [Living Documentation](https://ci.appveyor.com/api/projects/godrose/Attest/artifacts/output/Attest.Fake.Setup.Specs.LivingDoc.html) | [Get package](https://www.nuget.org/packages/Attest.Fake.Setup)|
| Moq | <img src=https://img.shields.io/nuget/dt/Attest.Fake.Moq>| [Living Documentation](https://ci.appveyor.com/api/projects/godrose/Attest/artifacts/output/Attest.Fake.Moq.Specs.LivingDoc.html) | [Get package](https://www.nuget.org/packages/Attest.Fake.Moq/) |
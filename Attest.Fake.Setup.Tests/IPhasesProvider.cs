using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;

namespace Attest.Fake.Setup.Tests
{
    public interface IPhasesProvider
    {
        Guid[] GetPhasesByGauge(Guid gaugeId);
    }

    public class PhasesProviderBuilder : FakeBuilderBase<IPhasesProvider>
    {
        private readonly Dictionary<Guid, List<PhaseDto>> _phases = new Dictionary<Guid, List<PhaseDto>>();

        public static PhasesProviderBuilder CreateBuilder()
        {
            return new PhasesProviderBuilder();
        }

        public void WithPhases(Guid gaugeId, IEnumerable<PhaseDto> phases)
        {
            if (_phases.ContainsKey(gaugeId) == false)
            {
                _phases.Add(gaugeId, new List<PhaseDto>());
            }
            _phases[gaugeId].AddRange(phases);
        }

        private IHaveNoMethods<IPhasesProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        protected override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();
            var setup = initialSetup.AddMethodCallWithResult<Guid, Guid[]>(
                t => t.GetPhasesByGauge(It.IsAny<Guid>()),
                (r, id) =>
                    r.Complete(
                        k => _phases[k].Select(t => t.Id).ToArray()));
            setup.Build();
        }
    }

    public class PhaseDto
    {
        public Guid GaugesId { get; set; }
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}

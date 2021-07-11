using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Attest.Testing.Serialization.Specs
{
    public interface ISimpleProvider
    {
        IEnumerable<SimpleItemDto> GetSimpleItems();
    }
}
using FluentAssertions;
using Xunit;

namespace LightMock.Tests
{       
    public class TheTests
    {
        [Fact]
        public void IsAnyValue_ReturnsDefaultValue()
        {
            The<string>.IsAnyValue.Should().Be(default(string));            
        }

        [Fact]
        public void Is_AnyPredicate_ReturnsDefaultValue()
        {
            The<string>.Is(s => true).Should().Be(default(string));            
        }
    }
}
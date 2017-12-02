using System;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace LightMock.Tests
{         
    public class MatchInfoTests
    {
        [Fact]
        public void Matches_SameValue_ReturnsTrue()
        {
            var predicateBuilder = new MatchInfoBuilder();
            Expression<Action<IFoo>> expression = (f) => f.Execute("SomeValue");
            
            var matchInfo = predicateBuilder.Build(expression);            

            var invocationInfo = new InvocationInfo(
                typeof(IFoo).GetMethod("Execute", new Type[] { typeof(string) }),
                new[] { "SomeValue" });

            matchInfo.Matches(invocationInfo).Should().BeTrue();            
        }

        [Fact]
        public void Matches_DifferentValue_ReturnsFalse()
        {
            var predicateBuilder = new MatchInfoBuilder();
            Expression<Action<IFoo>> expression = (f) => f.Execute("SomeValue");

            var matchInfo = predicateBuilder.Build(expression);

            var invocationInfo = new InvocationInfo(
                typeof(IFoo).GetMethod("Execute", new Type[] { typeof(string) }),
                new[] { "AnotherValue" });

            matchInfo.Matches(invocationInfo).Should().BeFalse();
        }

        [Fact]
        public void Matches_SameValueDifferentMethod_ReturnsFalse()
        {
            var predicateBuilder = new MatchInfoBuilder();
            Expression<Action<IFoo>> expression = (f) => f.Execute("SomeValue");

            var matchInfo = predicateBuilder.Build(expression);

            var invocationInfo = new InvocationInfo(
                typeof(IBar).GetMethod("Execute", new Type[] { typeof(string) }),
                new[] { "SomeValue" });

            matchInfo.Matches(invocationInfo).Should().BeTrue();
        }

        [Fact]
        public void Matches_ArgumentCountMismatch_ReturnsFalse()
        {
            var predicateBuilder = new MatchInfoBuilder();
            Expression<Action<IFoo>> expression = (f) => f.Execute("SomeValue");

            var matchInfo = predicateBuilder.Build(expression);

            var invocationInfo = new InvocationInfo(
                typeof(IFoo).GetMethod("Execute", new Type[] { typeof(string) }),
                new[] { "SomeValue", "AnotherValue" });

            matchInfo.Matches(invocationInfo).Should().BeTrue();
        }
    }
}
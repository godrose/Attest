using FluentAssertions;
using Xunit;

namespace LightMock.Tests
{       
    public class ArrangementTests
    {
        [Fact]
        public void Arrange_CallBackNoArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            bool isCalled = false;
            mockContext.Arrange(f => f.Execute()).Callback(() => isCalled = true);
            fooMock.Execute();
            isCalled.Should().BeTrue();            
        }

        [Fact]
        public void Arrange_CallBackOneArgument_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int callBackResult = 0;
            mockContext.Arrange(f => f.Execute(The<int>.IsAnyValue)).Callback<int>(s => callBackResult = s);
            fooMock.Execute(1);
            callBackResult.Should().Be(1);            
        }

        [Fact]
        public void Arrange_CallBackTwoArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int firstResult = 0;
            int secondResult = 0;
            mockContext.Arrange(f => f.Execute(The<int>.IsAnyValue, The<int>.IsAnyValue)).Callback<int, int>(
                (i, i1) =>
                {
                    firstResult = i;
                    secondResult = i1;
                });
            fooMock.Execute(1, 2);
            firstResult.Should().Be(1);
            secondResult.Should().Be(2);            
        }

        [Fact]
        public void Arrange_CallBackThreeArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int firstResult = 0;
            int secondResult = 0;
            int thirdResult = 0;
            mockContext.Arrange(f => f.Execute(The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue))
                .Callback<int, int, int>(
                    (i1, i2, i3) =>
                    {
                        firstResult = i1;
                        secondResult = i2;
                        thirdResult = i3;
                    });

            fooMock.Execute(1, 2, 3);

            firstResult.Should().Be(1);
            secondResult.Should().Be(2);
            thirdResult.Should().Be(3);
        }

        [Fact]
        public void Arrange_CallBackFourArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int firstResult = 0;
            int secondResult = 0;
            int thirdResult = 0;
            int fourthResult = 0;
            mockContext.Arrange(
                f => f.Execute(The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue))
                .Callback<int, int, int, int>(
                    (i1, i2, i3, i4) =>
                    {
                        firstResult = i1;
                        secondResult = i2;
                        thirdResult = i3;
                        fourthResult = i4;
                    });

            fooMock.Execute(1, 2, 3, 4);

            firstResult.Should().Be(1);
            secondResult.Should().Be(2);
            thirdResult.Should().Be(3);
            fourthResult.Should().Be(4);
        }

        [Fact]
        public void Arrange_CallBackFiveArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int firstResult = 0;
            int secondResult = 0;
            int thirdResult = 0;
            int fourthResult = 0;
            int fifthResult = 0;
            mockContext.Arrange(
                f => f.Execute(The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue))
                .Callback<int, int, int, int, int>(
                    (i1, i2, i3, i4, i5) =>
                    {
                        firstResult = i1;
                        secondResult = i2;
                        thirdResult = i3;
                        fourthResult = i4;
                        fifthResult = i5;
                    });

            fooMock.Execute(1, 2, 3, 4, 5);

            firstResult.Should().Be(1);
            secondResult.Should().Be(2);
            thirdResult.Should().Be(3);
            fourthResult.Should().Be(4);
            fifthResult.Should().Be(5);
        }

        [Fact]
        public void Arrange_CallBackSixArguments_InvokesCallback()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            int firstResult = 0;
            int secondResult = 0;
            int thirdResult = 0;
            int fourthResult = 0;
            int fifthResult = 0;
            int sixthResult = 0;
            mockContext.Arrange(
                f => f.Execute(The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue, The<int>.IsAnyValue))
                .Callback<int, int, int, int, int, int>(
                    (i1, i2, i3, i4, i5, i6) =>
                    {
                        firstResult = i1;
                        secondResult = i2;
                        thirdResult = i3;
                        fourthResult = i4;
                        fifthResult = i5;
                        sixthResult = i6;
                    });

            fooMock.Execute(1, 2, 3, 4, 5, 6);

            firstResult.Should().Be(1);
            secondResult.Should().Be(2);
            thirdResult.Should().Be(3);
            fourthResult.Should().Be(4);
            fifthResult.Should().Be(5);
            sixthResult.Should().Be(6);
        }

        [Fact]
        public void Arrange_ReturnsWithNoArguments_InvokesGetResult()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);

            mockContext.Arrange(f => f.Execute()).Returns(() => "This");
            var result = fooMock.Execute();
            result.Should().Be("This");            
        }

        [Fact]
        public void Arrange_ReturnsWithOneArgument_InvokesGetResult()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            mockContext.Arrange(f => f.Execute(The<string>.IsAnyValue)).Returns<string>(a => "This" + a);
            var result = fooMock.Execute(" is");
            result.Should().Be("This is");            
        }

        [Fact]
        public void Arrange_ReturnsWithTwoArguments_InvokesGetResult()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            mockContext.Arrange(f => f.Execute(The<string>.IsAnyValue, The<string>.IsAnyValue))
                .Returns<string, string>((a, b) => "This" + a + b);
            var result = fooMock.Execute(" is", " really");
            result.Should().Be("This is really");            
        }

        [Fact]
        public void Arrange_ReturnsWithThreeArguments_InvokesGetResult()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            mockContext.Arrange(f => f.Execute(The<string>.IsAnyValue, The<string>.IsAnyValue, The<string>.IsAnyValue))
                .Returns<string, string, string>((a, b, c) => "This" + a + b + c);

            var result = fooMock.Execute(" is", " really", " cool");
            result.Should().Be("This is really cool");            
        }

        [Fact]
        public void Arrange_ReturnsWithFourArguments_InvokesGetResult()
        {
            var mockContext = new MockContext<IFoo>();
            var fooMock = new FooMock(mockContext);
            mockContext.Arrange(
                f =>
                    f.Execute(
                        The<string>.IsAnyValue,
                        The<string>.IsAnyValue,
                        The<string>.IsAnyValue,
                        The<string>.IsAnyValue))
                .Returns<string, string, string, string>((a, b, c, d) => "This" + a + b + c + d);
            fooMock.Execute(1, 2, 3, 4);

            var result = fooMock.Execute(" is", " really", " cool", "!");
            result.Should().Be("This is really cool!");
        }
    }
}
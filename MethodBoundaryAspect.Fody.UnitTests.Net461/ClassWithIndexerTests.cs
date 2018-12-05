using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public class ClassWithIndexerTests : MethodBoundaryAspectTestBaseNet461
    {
        [Fact]
        public void IfClassContainsIndexer_ThenTheAssemblyShouldBeValid()
        {
            // Arrange
            const string testMethodName = "DummyMethod";
            var testClassType = typeof(ClassWithIndexer);
            
            // Act
            WeaveAssemblyClassAndLoad(testClassType);
            Action call = () => AssemblyLoader.InvokeMethod(testClassType.TypeInfo(), testMethodName);

            // Assert
            RunIlSpy();
            call.Should().NotThrow();
        }
    }
}
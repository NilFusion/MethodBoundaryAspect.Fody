using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public class NonStandardPropertiesTests : MethodBoundaryAspectTestBaseNet461
    {
        [Fact]
        public void IfPropertyWithDoubleUnderscoreIsWeaved_ThenTheAssemblyShouldBeValid()
        {
            // Arrange
            var testClassType = typeof(NonStandardProperties);

            // Act
            Action call = () => WeaveAssemblyClassAndLoad(testClassType);

            // Assert
            call.Should().NotThrow();
        }
    }
}
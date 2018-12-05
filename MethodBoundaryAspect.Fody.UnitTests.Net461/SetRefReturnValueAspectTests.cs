using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Shared.UnverifiableTestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public class SetRefReturnValueAspectTests : MethodBoundaryAspectTestBaseNet461
    {
        private static readonly Type TestClassType = typeof(SetReturnValueAspectMethods);

        [Fact]
        public void IfInstanceMethodWithRefReturnTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "InstanceMethodCall_RefReturnValueType";
            WeaveAssemblyClassAndLoad(TestClassType);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be(10);
        }

        [Fact]
        public void IfInstanceMethodWithRefReturnReferenceTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "InstanceMethodCall_RefReturnReferenceType";
            WeaveAssemblyClassAndLoad(TestClassType);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("overwritten");
        }

        [Fact]
        public void IfMethodWithRefReturnHasOverwrittenReturnValue_ThenTheOverwrittenValueIsReturned()
        {
            // Arrange
            const string testMethodName = "TestRefReturnValueOverwritten";
            WeaveAssemblyClassAndLoad(typeof(SetReturnValueAspectMethods));

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);
            
            // Assert
            result.Should().Be("42");
        }
    }
}

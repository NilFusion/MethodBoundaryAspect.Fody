﻿using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public class SetReturnValueAspectTests : MethodBoundaryAspectTestBaseNet461
    {
        private static readonly Type TestClassType = typeof (SetReturnValueAspectMethods);
        
        [Fact]
        public void IfStaticMethodWithValueTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "StaticMethodCall_ValueType";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be(42);
        }

        [Fact]
        public void IfInstanceMethodWithValueTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "InstanceMethodCall_ValueType";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be(43);
        }

        [Fact]
        public void IfStaticMethodWithReferenceTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "StaticMethodCall_ReferenceType";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("42");
        }

        [Fact]
        public void IfInstanceMethodWithReferenceTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "InstanceMethodCall_ReferenceType";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethod(TestClassType.TypeInfo(), testMethodName);

            // Assert
            result.Should().Be("43");
        }
    }
}
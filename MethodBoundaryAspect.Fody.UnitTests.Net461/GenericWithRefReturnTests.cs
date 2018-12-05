﻿using System.Collections.Generic;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly;
using MethodBoundaryAspect.Fody.UnitTests.Shared.UnverifiableTestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public class GenericWithRefReturnTests : GenericTestBase
    {
        public static IEnumerable<object[]> Methods { get => GetMethodNames(typeof(UnverifiableGenerics<Disposable>)); }

        public GenericWithRefReturnTests()
        {
            OpenClassType = typeof(UnverifiableGenerics<>);
            ClosedClassType = OpenClassType.MakeGenericType(typeof(Disposable));
        }

        [Theory, MemberData(nameof(Methods))]
        public void IfMethodWithRefReturnTypeIsWeaved_ThenResultIsExpected(string methodName)
        {
            // Arrange
            SetClosedMethod(methodName);

            // Act
            Weave(methodName);
            object result = Run("Test" + methodName);

            // Assert
            var results = result as List<string>;
            results[0].Trim().Should().Be(ExpectedEntryString(methodName));
            results[1].Trim().Should().Be(ExpectedExitString(methodName));
            results.Count.Should().Be(2);
        }
    }
}

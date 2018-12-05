﻿using System;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetMethodExecutionTagValueOnExceptionAspectMethods
    {
        public static object Result { get; set; }

        [SetMethodExecutionTagValueOnExceptionAspect1]
        [SetMethodExecutionTagValueOnExceptionAspect2]
        public static void StaticMethodCall()
        {
            throw new Exception("forced");
        }

        [SetMethodExecutionTagValueOnExceptionAspect1]
        [SetMethodExecutionTagValueOnExceptionAspect2]
        public void InstanceMethodCall()
        {
            throw new Exception("forced");
        }
    }
}
﻿using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetInstanceValueAspectMethods
    {
        public static object Result { get; set; }

        [SetInstanceValueAspect]
        public static void StaticMethodCall()
        {
        }

        [SetInstanceValueAspect]
        public void InstanceMethodCall()
        {
        }

        public override string ToString()
        {
            return "SetInstanceValueAspectMethods->ToString()";
        }
    }
}
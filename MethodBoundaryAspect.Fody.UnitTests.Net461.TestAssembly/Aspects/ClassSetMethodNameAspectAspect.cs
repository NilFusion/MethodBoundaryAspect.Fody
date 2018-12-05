﻿using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects
{
    public class ClassSetMethodNameAspectAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            ClassSetMethodNameAspect.Result =
                arg.Method == null
                    ? "No method info found"
                    : arg.Method.Name;
        }
    }
}
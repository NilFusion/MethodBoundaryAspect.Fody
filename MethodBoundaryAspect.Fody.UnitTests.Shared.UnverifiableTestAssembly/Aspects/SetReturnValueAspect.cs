﻿using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Shared.UnverifiableTestAssembly.Aspects
{
    public class SetReturnValueAspect : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs arg)
        {
            SetReturnValueAspectMethods.Result = arg.ReturnValue;
        }
    }
}

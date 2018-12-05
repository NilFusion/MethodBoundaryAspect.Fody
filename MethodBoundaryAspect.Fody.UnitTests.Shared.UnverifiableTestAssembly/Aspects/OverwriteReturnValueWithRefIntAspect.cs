﻿using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Shared.UnverifiableTestAssembly.Aspects
{
    public class OverwriteReturnValueWithRefIntAspect : OnMethodBoundaryAspect
    {
        int _key;

        public OverwriteReturnValueWithRefIntAspect(int key)
        {
            _key = key;
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            arg.ReturnValue = _key;
        }
    }
}

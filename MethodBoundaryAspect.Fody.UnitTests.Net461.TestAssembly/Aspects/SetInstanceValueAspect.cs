﻿using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects
{
    public class SetInstanceValueAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            if (arg.Instance == null)
            {
                SetInstanceValueAspectMethods.Result = "instance was null";
                return;
            }

            SetInstanceValueAspectMethods.Result = arg.Instance.ToString();
        }
    }
}
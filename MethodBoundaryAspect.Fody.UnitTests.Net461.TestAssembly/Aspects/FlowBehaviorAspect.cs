﻿using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects
{
    public class FlowBehaviorAspect : OnMethodBoundaryAspect
    {
        public FlowBehavior Behavior { get; set; }
        public object ReturnValue { get; set; }
        
        public override void OnException(MethodExecutionArgs arg)
        {
            arg.FlowBehavior = Behavior;
            arg.ReturnValue = ReturnValue;
        }
    }
}

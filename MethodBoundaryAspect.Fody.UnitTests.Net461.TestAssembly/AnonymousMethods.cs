using System;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    [OnlyOnEntryAspect]
    public class AnonymousMethods
    {
        public object Result { get; set; }

        public void CallAnonymousMethod()
        {
            Action action = () => Result = "CallAnonymousMethod";
            action();
        }
    }
}
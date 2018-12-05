using System;
using MethodBoundaryAspect.Fody.UnitTests.Shared.TestAssemblyAspects;

namespace MethodBoundaryAspect.Fody.UnitTests.NetCore21.TestAssembly
{
    [AddLogs]
    public class SimpleClassWithVoidMethod : IResult
    {
        public object InstanceResult { get; set; }

        public void SimpleMethod()
        {
            throw new Exception("thrown Exception");
        }
    }
}

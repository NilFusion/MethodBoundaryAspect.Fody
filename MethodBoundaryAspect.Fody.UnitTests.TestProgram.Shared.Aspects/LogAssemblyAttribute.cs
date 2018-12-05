using System;
using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.TestProgram.Shared.Aspects
{
    public class LogAssemblyAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            Console.WriteLine("LogAssemblyAttribute->Method called: " + arg.Method.Name);
        }
    }
}
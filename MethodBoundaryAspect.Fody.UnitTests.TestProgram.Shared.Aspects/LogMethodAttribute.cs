using System;
using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.TestProgram.Shared.Aspects
{
    public class LogMethodAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            Console.WriteLine("LogMethodAttribute->Method called: " + arg.Method.Name);
        }
    }
}
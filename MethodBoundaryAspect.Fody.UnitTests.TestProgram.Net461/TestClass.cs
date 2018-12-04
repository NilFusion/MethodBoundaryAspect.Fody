using System;
using MethodBoundaryAspect.Fody.UnitTests.TestProgram.Shared.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.TestProgram.Net461
{
    [LogClass]
    public class TestClass
    {
        [LogMethod]
        public void DoIt(int zahl)
        {
            Console.WriteLine("<method body called with arg '{0}'>", zahl);
        }
    }
}
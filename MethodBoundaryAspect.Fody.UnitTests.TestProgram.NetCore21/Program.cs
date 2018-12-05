using System.Diagnostics;

namespace MethodBoundaryAspect.Fody.UnitTests.TestProgram.NetCore21
{
    class Program
    {
        static void Main(string[] args)
        {
            //If no debugger is attached launch the debugger
            if (Debugger.IsAttached == false)
                Debugger.Launch();
            Debugger.Break();

            var testClass = new TestProgramClass();
            testClass.DoIt(7);
        }
    }
}

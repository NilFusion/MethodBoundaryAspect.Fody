using System.Diagnostics;
using MethodBoundaryAspect.Fody.UnitTests.NetStandard2.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetCore21
{
    public class WeavingTestsNetStandardAssembly : MethodBoundaryAspectNetCore21TestBase
    {
        
        [Fact]
        public void IfNetStandardClassIsWeaved_ThenThereShouldBeNoException()
        {
            //Debugger.Launch();
            //Debugger.Break();

            WeaveAssemblyClass(typeof(SimpleClassWithMethod));
        }
    }
}
using System.Diagnostics;
using MethodBoundaryAspect.Fody.UnitTests.NetStandard2.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetCore21
{
    public class WeavingTestsNetStandardAssembly : MethodBoundaryAspectNetCore21TestBase
    {
        public WeavingTestsNetStandardAssembly()
        {
            ExecutePeVerify = false;
        }

        [Fact]
        public void IfNetStandardClassIsWeaved_ThenThereShouldBeNoException()
        {
            WeaveAssemblyClass(typeof(SimpleClassWithMethod));
        }
    }
}
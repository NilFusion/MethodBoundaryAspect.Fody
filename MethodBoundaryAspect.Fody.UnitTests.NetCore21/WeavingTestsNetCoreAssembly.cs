using MethodBoundaryAspect.Fody.UnitTests.NetCore21.TestAssembly;
using MethodBoundaryAspect.Fody.UnitTests.TestProgram.NetCore21;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetCore21
{
    public class WeavingTestsNetCoreAssembly : MethodBoundaryAspectNetCore21TestBase
    {
        [Fact]
        public void IfSimpleClassWithMethodIsWeaved_ThenThereShouldBeNoException()
        {
            WeaveAssemblyClass(typeof(SimpleClassWithMethod));
        }

        [Fact]
        public void IfSimpleClassWithVoidMethodIsWeaved_ThenThereShouldBeNoException()
        {
            WeaveAssemblyClass(typeof(SimpleClassWithVoidMethod));
        }

        [Fact]
        public void IfTestProgramIsWeaved_ThenThereShouldBeNoException()
        {
            WeaveAssemblyClass(typeof(TestProgramClass));
        }
    }
}

using MethodBoundaryAspect.Fody.UnitTests.Shared.TestAssemblyAspects;

namespace MethodBoundaryAspect.Fody.UnitTests.NetStandard2.TestAssembly
{

    public class SimpleClassWithMethod
    {
        [ReturnValuePlusN(1)]
        public int ReturnValue(int number)
        {
            return number;
        }
    }
}

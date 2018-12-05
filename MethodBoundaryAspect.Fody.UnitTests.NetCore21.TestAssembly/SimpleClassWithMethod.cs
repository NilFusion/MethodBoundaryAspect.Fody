using MethodBoundaryAspect.Fody.UnitTests.Shared.TestAssemblyAspects;

namespace MethodBoundaryAspect.Fody.UnitTests.NetCore21.TestAssembly
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

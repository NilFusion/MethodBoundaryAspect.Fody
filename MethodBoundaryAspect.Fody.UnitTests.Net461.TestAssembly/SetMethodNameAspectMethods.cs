using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetMethodNameAspectMethods
    {
        public static object Result { get; set; }

        [SetMethodNameAspect]
        public static void StaticMethodCall()
        {
        }

        [SetMethodNameAspect]
        public void InstanceMethodCall()
        {
        }
    }
}
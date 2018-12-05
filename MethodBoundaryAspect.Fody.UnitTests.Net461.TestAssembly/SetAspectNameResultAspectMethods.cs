using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetAspectNameResultAspectMethods
    {
        public static object Result { get; set; }

        [SetAspectNameResultAspect]
        public static void StaticMethodCall()
        {
        }

        [SetAspectNameResultAspect]
        public void InstanceMethodCall()
        {
        }
    }
}

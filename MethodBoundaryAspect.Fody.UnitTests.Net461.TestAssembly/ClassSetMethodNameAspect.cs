using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    [ClassSetMethodNameAspectAspect]
    public class ClassSetMethodNameAspect
    {
        public static object Result { get; set; }

        public static void ClassStaticMethodCall()
        {
        }

        public void ClassInstanceMethodCall()
        {
        }
    }
}
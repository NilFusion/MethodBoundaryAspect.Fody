using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    [FirstAspect]
    [SecondAspect]
    public class MultipleAspectsMethods
    {
        public static string Result { get; set; }

        public static void StaticMethodCall()
        {
        }

        public void InstanceMethodCall()
        {
        }
    }
}
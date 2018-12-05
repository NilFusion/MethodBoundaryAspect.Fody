using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetMethodExecutionTagValueOnExitAspectMethods
    {
        public static object Result { get; set; }

        [SetMethodExecutionTagValueOnExitAspect1]
        [SetMethodExecutionTagValueOnExitAspect2]
        public static void StaticMethodCall()
        {
        }

        [SetMethodExecutionTagValueOnExitAspect1]
        [SetMethodExecutionTagValueOnExitAspect2]
        public void InstanceMethodCall()
        {
        }
    }
}
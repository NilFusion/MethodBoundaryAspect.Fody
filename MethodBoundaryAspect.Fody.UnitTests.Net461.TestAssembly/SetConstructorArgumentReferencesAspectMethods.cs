using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SetConstructorArgumentReferencesAspectMethods
    {
        public static object Result { get; set; }

        [SetConstructorArgumentReferencesAspect(typeof(string), "TestText")]
        public static void StaticMethodCall()
        {
        }

        [SetConstructorArgumentReferencesAspect(typeof(string), "TestText")]
        public void InstanceMethodCall()
        {
        }
    }
}
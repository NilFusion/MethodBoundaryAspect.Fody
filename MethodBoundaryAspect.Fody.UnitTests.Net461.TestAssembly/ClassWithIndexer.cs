using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class ClassWithIndexer
    {
        [PropertyAspect]
        public bool this[object value] => true;

        [PropertyAspect]
        public bool this[string value] => true;

        public static void DummyMethod()
        {
        }
    }
}
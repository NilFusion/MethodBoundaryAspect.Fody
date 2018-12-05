using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public struct Struct
    {
        public static object Result { get; set; }

        [StructSetter]
        public void InstanceMethodCall_ReferenceType(string s1) { }

        [StructSetter]
        public static void StaticMethodCall_ReferenceType(string s1) { }
    }
}

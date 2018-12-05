using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class PropertyAspectMethods
    {
        public static object Result { get; set; }

        [PropertyAspect]
        public static string StaticProperty { get; set; }

        [PropertyAspect]
        public static string InstanceProperty { get; set; }

        public static string StaticMethodCall()
        {
            StaticProperty = "StaticValue";
            return StaticProperty;
        }

        public string InstanceMethodCall()
        {
            InstanceProperty = "InstanceValue";
            return InstanceProperty;
        }
    }
}
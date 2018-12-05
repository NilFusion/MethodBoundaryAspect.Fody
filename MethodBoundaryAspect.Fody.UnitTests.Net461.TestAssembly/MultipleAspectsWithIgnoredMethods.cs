using MethodBoundaryAspect.Fody.Attributes;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    [FirstAspect]
    [SecondAspect]
    public class MultipleAspectsWithIgnoredMethods
    {
        public void InstanceMethodCall()
        {
        }

        [DisableWeaving]
        public void PublicMethodIgnoredFromWeaving()
        {
        }

        [DisableWeaving]
        private void PrivateMethodIgnoredFromWeaving()
        {
        }
    }
}
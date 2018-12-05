using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class SpecialAspectMethods
    {
        [OnlyOnEntryAspect]
        public void MethodWithAspectOnEntryOnly()
        {
        }

        [OnlyOnExitAspect]
        public void MethodWithAspectOnExitOnly()
        {
        }

        [OnlyOnExceptionAspect]
        public void MethodWithAspectOnExceptionOnly()
        {
        }
    }
}
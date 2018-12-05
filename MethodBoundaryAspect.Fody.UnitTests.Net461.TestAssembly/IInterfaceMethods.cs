using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    [OnlyOnEntryAspect]
    public interface IInterfaceMethods
    {
        void DoSomething();
    }
}
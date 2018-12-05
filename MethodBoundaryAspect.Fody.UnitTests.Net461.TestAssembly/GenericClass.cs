using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class GenericClass<T>
    {
        [SetInstanceValueAspect]
        public void DoIt()
        {
        }

        public void DoItNotWeaved()
        {
        }

        public void CallOther()
        {
            var thisRef = this;
            DoIt();
        }
    }
}
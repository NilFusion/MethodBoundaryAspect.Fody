namespace MethodBoundaryAspect.Fody.UnitTests.Net461.MultipleAspects.FailTests
{
    public class TestFailMethods
    {
        [RoleAndSameOrderingAspect]
        public void VoidEmptyMethod()
        {
        }

        [FirstAspect]
        [SecondAspect]
        [UnorderedAspect]
        public void VoidEmptyMethodUnorderedAspectMixedWithOrderedAspect()
        {
        }
    }
}
using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.MultipleAspects.FailTests
{
    [ProvideAspectRole(TestRoles.Third)]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.Before, TestRoles.Third)]
    public class RoleAndSameOrderingAspect : OnMethodBoundaryAspect
    {
    }
}
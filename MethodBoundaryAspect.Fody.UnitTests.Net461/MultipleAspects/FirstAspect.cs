using System;
using System.Diagnostics;
using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.MultipleAspects
{
    [ProvideAspectRole(TestRoles.First)]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.Before, TestRoles.Second)]
    public class FirstAspect : OnMethodBoundaryAspect
    {
        private const string MethodExecutionTagValue = TestRoles.First;

        public override void OnEntry(MethodExecutionArgs arg)
        {
            Debug.WriteLine("FirstAspect - OnEntry called for: " + arg.Method.Name);
            arg.MethodExecutionTag = MethodExecutionTagValue;
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            Debug.WriteLine("FirstAspect - OnExit called for: " + arg.Method.Name);
            var value = (string) arg.MethodExecutionTag;
            Debug.WriteLine("FirstAspect - MethodExecutionTag is: " + value);
            if (value != MethodExecutionTagValue)
                throw new InvalidOperationException("FirstAspect - MethodExecutionTag was changed outside of aspect");
        }
    }
}